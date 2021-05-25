using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PormBladeController : MonoBehaviour
{
    
    [SerializeField] private Transform _CurrentTargetTransformPosition;


    public bool OnTheMechine { get; set; } = false;
    public bool OnTheActionPoint { get; set; } = false;

    private InputDevice device;
    private List<InputDevice> devices = new List<InputDevice>();
    private bool primaryButtonIsPressed;
    private bool secondsButtonIsPressed;
    [SerializeField]
    XRNode xRNode = XRNode.RightHand;

    public XRNode controllerNode
    {
        get => xRNode;
        set => xRNode = value;
    }
    void Start()
    {
        OnEnable();
        OnSetup(); 
    }

    void OnSetup() {


        if (_CurrentTargetTransformPosition == null) {
            _CurrentTargetTransformPosition = gameObject.transform.Find("Tool Head").gameObject.GetComponent<Transform>();
        }
    }

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xRNode, devices);
        if (devices.Count > 0)
        {
            device = devices[0];
        }

    }

    void OnEnable()
    {
        if (!device.isValid)
        {
            GetDevice();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OnTheMechine)
        {
            
            if (OnTheActionPoint)
            {
                

                // capturing primary button press and release
                bool primaryButtonValue = false;
                InputFeatureUsage<bool> primaryButtonUsage = CommonUsages.primaryButton;

                if (device.TryGetFeatureValue(primaryButtonUsage, out primaryButtonValue) && primaryButtonValue && !primaryButtonIsPressed)
                {
                    primaryButtonIsPressed = true;

                    Debug.Log($"PrimaryButton activated {primaryButtonValue} {primaryButtonIsPressed} on {xRNode}");
                }
                else if (!primaryButtonValue && primaryButtonIsPressed)
                {
                    primaryButtonIsPressed = false;
                    Debug.Log($"PrimaryButton deactivated {primaryButtonValue} on {xRNode}");
                }

                bool secondsButtonValue = false;
                InputFeatureUsage<bool> secondsButtonUsage = CommonUsages.secondaryButton;

                if (device.TryGetFeatureValue(secondsButtonUsage, out secondsButtonValue) && secondsButtonValue && !secondsButtonIsPressed)
                {
                    secondsButtonIsPressed = true;

                    Debug.Log($"SecondaryButton activated {secondsButtonValue} {secondsButtonIsPressed} on {xRNode}");
                }
                else if (!secondsButtonValue && secondsButtonIsPressed)
                {
                    secondsButtonIsPressed = false;
                    Debug.Log($"SecondaryButton deactivated {secondsButtonValue} on {xRNode}");
                }

                if (secondsButtonIsPressed)
                {

                    RotateWithNegetive();
                }
                if (primaryButtonIsPressed)
                {
                    RotateWithPositive();

                }

            }

        }
    }

    public void updateRotationOfValve(float angles)
    {

        var turn = transform.localEulerAngles.y;
        /*turn = (turn > 180) ? turn - 360 : turn;*/
        var speedRate = new Vector3(0, angles * 10, 0); ;

        transform.Rotate(speedRate);
        
        
    }

    void RotateWithPositive() {
        var speed = 0.1f;
        var speedRate = new Vector3(speed, 0, 0);
        updateRotationOfValve(speed);
    }

    void RotateWithNegetive()
    {
        var speed = -0.1f;
        var speedRate = new Vector3(speed, 0, 0);
        updateRotationOfValve(speed);
    }
}
