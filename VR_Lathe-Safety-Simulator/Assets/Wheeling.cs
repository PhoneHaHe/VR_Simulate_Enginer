using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Wheeling : InputManager
{
    // public InputDeviceCharacteristics controllerCharacteristics;
    // private InputDevice targetDevices;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     List<InputDevice> devices = new List<InputDevice>();

    //     InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     TryInitializeController();
    // }
    // void FixedUpdate() {
    //     TryInitializeController();
    // }

    // void TryInitializeController() {

    //     targetDevices.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
    //     if (primaryButtonValue)
    //     {
    //         Debug.Log("Pressing Primary Button");
    //     }

    //     targetDevices.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
    //     if (triggerValue > 0.1f)
    //     {
    //         Debug.Log("Trigger pressed" + triggerValue);
    //     }

    //     targetDevices.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
    //     if (primary2DAxisValue != Vector2.zero)
    //     {
    //         Debug.Log("Primary Touchpad " + primary2DAxisValue);
    //     }
    // }

    
}
