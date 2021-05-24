﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RectanglerodAction : MonoBehaviour
{
    public bool OnTheMechine { get; set; } = false;
    public bool OnTheActionPoint { get; set; } = false;
    [SerializeField] private Transform _LockObjects;
    private LockObjects _lockObject;
    [SerializeField] private Transform _TargetRotationAction;

    [SerializeField] private Transform _TargetRotationActionTwo;


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
        /*Debug.LogError(target.name);*/
        _lockObject = _LockObjects.GetComponent<LockObjects>();

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
        OnCallAction();
    }

    void OnCallAction() {

        if (OnTheMechine)
        {
            if (OnTheActionPoint) {

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

                    _lockObject.TurnLock = true;
                    rotationByAngle();
                }
                if (primaryButtonIsPressed)
                {
                    _lockObject.TurnUnLock = true;
                    rotationByAngleReturn();

                }

            }

        }
    }

    void rotationByAngle() {

        _TargetRotationAction.transform.rotation = Quaternion.Euler(_TargetRotationAction.transform.eulerAngles.x, _TargetRotationAction.transform.eulerAngles.y, 120f);
        _TargetRotationActionTwo.transform.rotation = Quaternion.Euler(_TargetRotationActionTwo.transform.eulerAngles.x, _TargetRotationActionTwo.transform.eulerAngles.y, 120f);
    }

    void rotationByAngleReturn()
    {

        _TargetRotationAction.transform.rotation = Quaternion.Euler(_TargetRotationAction.transform.eulerAngles.x, _TargetRotationAction.transform.eulerAngles.y, 0f);
        _TargetRotationActionTwo.transform.rotation = Quaternion.Euler(_TargetRotationActionTwo.transform.eulerAngles.x, _TargetRotationActionTwo.transform.eulerAngles.y, 0f);
    }

}
