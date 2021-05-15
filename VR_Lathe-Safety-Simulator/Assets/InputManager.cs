using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    XRNode m_ControllerNode = XRNode.RightHand;

    public XRNode controllerNode
    {
        get => m_ControllerNode;
        set => m_ControllerNode = value;
    }

    private List<InputDevice> devices = new List<InputDevice>();

    private InputDevice device;

    //to avoid repeat readings
    private bool triggerIsPressed;
    private bool primaryButtonIsPressed;
    private bool secondsButtonIsPressed;
    private bool primary2DAxisIsChosen;
    private Vector2 primary2DAxisValue = Vector2.zero;
    private Vector2 prevPrimary2DAxisValue;
    private bool gripIsPressed;

    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(m_ControllerNode, devices);

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

    void Update()
    {
        if (!device.isValid)
        {
            GetDevice();
        }

        // capturing trigger button press and release    
        bool triggerButtonValue = false;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonValue) && triggerButtonValue && !triggerIsPressed)
        {
            triggerIsPressed = true;
            Debug.Log($"TriggerButton activated {triggerButtonValue}");
        }
        else if (!triggerButtonValue && triggerIsPressed)
        {
            triggerIsPressed = false;
            Debug.Log($"TriggerButton deactivated {triggerButtonValue}");
        }

        // capturing primary button press and release
        bool primaryButtonValue = false;
        InputFeatureUsage<bool> primaryButtonUsage = CommonUsages.primaryButton;

        if (device.TryGetFeatureValue(primaryButtonUsage, out primaryButtonValue) && primaryButtonValue && !primaryButtonIsPressed)
        {
            primaryButtonIsPressed = true;
            Debug.Log($"PrimaryButton activated {primaryButtonValue}");
        }
        else if (!primaryButtonValue && primaryButtonIsPressed)
        {
            primaryButtonIsPressed = false;
            Debug.Log($"PrimaryButton deactivated {primaryButtonValue}");
        }

        // bool secondsButtonValue = false;
        // InputFeatureUsage<bool> secondsButtonUsage = CommonUsages.secondaryButton;

        // if (device.TryGetFeatureValue(secondsButtonUsage, out secondsButtonValue) && secondsButtonValue)
        // {
        //     secondsButtonIsPressed = true;
        //     Debug.Log($"SecondaryButton activated {secondsButtonValue}");
        // }
        // else if (!secondsButtonValue && secondsButtonIsPressed)
        // {
        //     secondsButtonIsPressed = false;
        //     Debug.Log($"SecondaryButton deactivated {secondsButtonValue}");
        // }

        bool secondButton = false;
        InputFeatureUsage<bool> secondeButtonUsage = CommonUsages.secondaryButton;
        if (device.TryGetFeatureValue(secondeButtonUsage, out secondButton) && secondButton)
        {
            Debug.Log($"SecondsButton activated {m_ControllerNode}");
        }

        // capturing primary 2D Axis changes and release
        InputFeatureUsage<Vector2> primary2DAxisUsage = CommonUsages.primary2DAxis;
        // make sure the value is not zero and that it has changed
        if (primary2DAxisValue != prevPrimary2DAxisValue)
        {
            primary2DAxisIsChosen = false;
            //Debug.Log($"CHANGED and prev value is {prevPrimary2DAxisValue} and the new value is {primary2DAxisValue}");
        }
        // was for checking to see if the axis values were reading as changed properly
        /* else
        {
            Debug.Log($"Nope, prev value is {prevPrimary2DAxisValue} and the new value is {primary2DAxisValue}");
        } */


        if (device.TryGetFeatureValue(primary2DAxisUsage, out primary2DAxisValue) && primary2DAxisValue != Vector2.zero && !primary2DAxisIsChosen)
        {
            prevPrimary2DAxisValue = primary2DAxisValue;
            primary2DAxisIsChosen = true;
            Debug.Log($"Primary2DAxis value activated {primary2DAxisValue}");
        }
        else if (primary2DAxisValue == Vector2.zero && primary2DAxisIsChosen)
        {
            prevPrimary2DAxisValue = primary2DAxisValue;
            primary2DAxisIsChosen = false;
            Debug.Log($"Primary2DAxis deactivated {primary2DAxisValue}");
        }

        // capturing grip value
        float gripValue;
        InputFeatureUsage<float> gripUsage = CommonUsages.grip;

        if (device.TryGetFeatureValue(gripUsage, out gripValue))
        //targetDevices.TryGetFeatureValue(CommonUsages.grip, out float gripValue)
        {
            gripIsPressed = true;
            Debug.Log($"Grip value {gripValue} activated");
        }
        else if (gripValue == 0 && gripIsPressed)
        {
            gripIsPressed = false;
            Debug.Log($"Grip value {gripValue} deactivated");
        }
    }
}

