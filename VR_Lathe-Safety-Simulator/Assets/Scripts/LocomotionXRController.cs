using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionXRController : MonoBehaviour
{
    
    public XRController lefTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public XRRayInteractor leftInteractorRay;
    public XRRayInteractor rightInteractorRay;
    public bool enableLeftTeleport { get; set; } = true;
    public bool enableRightTeleport {get; set;}= true;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        Vector3 pos = new Vector3();
        Vector3 nom = new Vector3();
        int index =0;
        bool validTarget = false;

        

        if(lefTeleportRay){
            bool isLeftInteractorRayHovering = leftInteractorRay.TryGetHitInfo(ref pos, ref nom, ref index, ref validTarget);
            lefTeleportRay.gameObject.SetActive(enableLeftTeleport && CheckIfActivated(lefTeleportRay) && !isLeftInteractorRayHovering);
        }

        if(rightTeleportRay){
            bool isRightInteractorRayHovering = rightInteractorRay.TryGetHitInfo(ref pos, ref nom, ref index, ref validTarget);
            rightTeleportRay.gameObject.SetActive(enableRightTeleport && CheckIfActivated(rightTeleportRay)&& !isRightInteractorRayHovering );
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated; 
    }
}
