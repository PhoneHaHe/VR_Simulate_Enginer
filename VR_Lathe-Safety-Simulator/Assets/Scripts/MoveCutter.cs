using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoveCutter : MonoBehaviour
{

    [SerializeField] private Transform _headCutter;
    private double _maxPositionToMoveUp;
    private double _minPositionToMoveDown;

    public bool OnTheMechine { get; set; } = false;
    public bool ToolOnTheMechine { get; set; } = false;
    public bool OnTheActionPoint { get; set; } = false;

    private InputDevice device;
    private List<InputDevice> devices = new List<InputDevice>();
    private bool primaryButtonIsPressed;
    private bool secondsButtonIsPressed;
    [SerializeField]
    XRNode xRNode = XRNode.RightHand;

    void Start()
    {
        OnStartSetup();
    }

    void OnStartSetup() {
        if(_headCutter == null) { 
        _headCutter = gameObject.transform.Find("HeadCuter Drop Location").GetComponent<Transform>();
        }
        var _originPosition = _headCutter.transform.localPosition; 
        _maxPositionToMoveUp = _originPosition.y + 0.60;
        _minPositionToMoveDown = _originPosition.y;
        
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
    void Update()
    {
        if (OnTheMechine && ToolOnTheMechine)
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

    public void updateRotationOfValve(Vector3 speed)
    {

        var turn = _headCutter.transform.localPosition.y;
        if (turn >= _minPositionToMoveDown || turn <= _maxPositionToMoveUp) {

            _headCutter.transform.localPosition = _headCutter.transform.localPosition + speed * Time.deltaTime;
        }

    }

    void RotateWithPositive()
    {
        var speed = 0.1f;
        var speedRate = new Vector3(0, speed, 0);
        updateRotationOfValve(speedRate);
    }

    void RotateWithNegetive()
    {
        var speed = -0.1f;
        var speedRate = new Vector3(0, speed, 0);
        updateRotationOfValve(speedRate);
    }
}
