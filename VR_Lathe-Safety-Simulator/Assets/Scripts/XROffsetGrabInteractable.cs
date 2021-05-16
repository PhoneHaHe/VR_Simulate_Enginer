using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    // Start is called before the first frame update
    private Vector3 intialAttachLocalPos;
    private Quaternion intialAttachLocalRot;
    void Start()
    {
        if(!attachTransform)
        {
        GameObject grab = new GameObject("Grab Pivot");
        grab.transform.SetParent(transform, false);
        attachTransform = grab.transform;
        }

        intialAttachLocalPos = attachTransform.localPosition;
        intialAttachLocalRot = attachTransform.localRotation;
    }

    
    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        if(interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }else{
            attachTransform.localPosition = intialAttachLocalPos;
            attachTransform.localRotation = intialAttachLocalRot;
        }
        base.OnSelectEntered(interactor);

    }
    
}
