using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnWhenDontGrabV2 : MonoBehaviour
{
    [SerializeField] GameObject TargetToReturn;
    public Vector3 positionToTransform;
    public Quaternion rotationToTranform;

    void Awake()
    {
        if (TargetToReturn != null) { 
            positionToTransform = TargetToReturn.transform.localPosition;
            rotationToTranform = TargetToReturn.transform.localRotation;
        }
    }

    public void ReturnToTarget()
    {
        TargetToReturn.transform.localPosition = positionToTransform;
        TargetToReturn.transform.localRotation = rotationToTranform;

        Debug.Log($"{positionToTransform}");
    }
}
