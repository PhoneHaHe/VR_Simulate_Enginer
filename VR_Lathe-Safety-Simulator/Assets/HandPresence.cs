﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevices;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0){
            targetDevices = devices[0];
        }

    }

    // Update is called once per frame
    void Update()
    {
        targetDevices.TryGetFeatureValue(CommonUsages.primaryButton,out bool primaryButtonValue);
        if(primaryButtonValue){
            Debug.Log("Pressing Primary Button");
        }

        targetDevices.TryGetFeatureValue(CommonUsages.trigger,out float triggerValue);
        if(triggerValue > 0.1f){
            Debug.Log("Trigger pressed" + triggerValue);
        }

        targetDevices.TryGetFeatureValue(CommonUsages.primary2DAxis,out Vector2 primary2DAxisValue);
        if(primary2DAxisValue != Vector2.zero){
            Debug.Log("Primary Touchpad " + primary2DAxisValue);
        }        
    }
}
