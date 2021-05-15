using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;
    private InputDevice targetDevices;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();

    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevices = devices[0];
            GameObject prefab = controllerPrefabs.Find(controllerCharacteristics => controllerCharacteristics.name == targetDevices.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    void UpdateHandAnimation()
    {

        if (targetDevices.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);

        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevices.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);

        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }

    }
    // Update is called once per frame
    void Update()
    {
        // targetDevices.TryGetFeatureValue(CommonUsages.primaryButton,out bool primaryButtonValue);
        // if(primaryButtonValue){
        //      Debug.Log("Pressing Primary Button");
        //  }

        // targetDevices.TryGetFeatureValue(CommonUsages.trigger,out float triggerValue);
        // if(triggerValue > 0.1f){
        //     Debug.Log("Trigger pressed" + triggerValue);
        // }

        // targetDevices.TryGetFeatureValue(CommonUsages.primary2DAxis,out Vector2 primary2DAxisValue);
        // if(primary2DAxisValue != Vector2.zero){
        //    Debug.Log("Primary Touchpad " + primary2DAxisValue);
        // }

        if (!targetDevices.isValid)
        {
            TryInitialize();

        }
        else
        {
            if (showController)
            {
                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);
            }
            else
            {
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnimation();
            }
        }

    }
}
