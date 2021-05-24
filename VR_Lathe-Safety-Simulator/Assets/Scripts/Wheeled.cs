using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Wheeled : MonoBehaviour
{
    // Object Target to management move
    [SerializeField] private Transform targetx;
    public Vector3 currentPositionOfPlatform;
    public float MaxPosition;
    public float MinPosition;
    public float speeds;
    public float rateRotate;
    public bool isHoldThisWheel { get; set; } = false;

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
        /*Debug.Log($"{targetx.transform.position} {targetx.name}");*/
        this.currentPositionOfPlatform = targetx.transform.position;

        OnEnable();
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
    void FixedUpdate()
    {


        updatePosition();
        if (isHoldThisWheel)
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
                if (currentPositionOfPlatform.x >= MinPosition)
                {
                    movePlatformByEulerAngles();
                }

            }
            if (primaryButtonIsPressed)
            {
                if (currentPositionOfPlatform.x <= MaxPosition)
                {
                    moveNegativePlatformByEulerAngles();
                }
            }
        }


    }

    public void updateRotationOfValve(float angles)
    {

        var turn = transform.localEulerAngles.z;
        /*turn = (turn > 180) ? turn - 360 : turn;*/
        var speedRate = new Vector3(0,0, angles * rateRotate); ;

        transform.Rotate(-speedRate);
    }

    private void movePlatformByEulerAngles()
    {
        var speed = - speeds;
        var speedRate = new Vector3(speed, 0, 0);
        updateRotationOfValve(speed);
        targetx.transform.position = targetx.transform.position + speedRate * Time.deltaTime;
    }

    private void moveNegativePlatformByEulerAngles()
    {
        var speed = speeds;
        var speedRate = new Vector3(speed, 0, 0);
        updateRotationOfValve(speed);
        targetx.transform.position = targetx.transform.position + speedRate * Time.deltaTime;
    }

    public void updatePosition()
    {

        currentPositionOfPlatform = targetx.transform.position;
    }
}
