using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnWhenDontGrab : MonoBehaviour
{
    [SerializeField] GameObject TargetToReturn;
    Vector3 positionToTransform;
    Quaternion rotationToTranform;

    void Awake() {
        if (TargetToReturn != null)
            positionToTransform = TargetToReturn.transform.localPosition;
            rotationToTranform = TargetToReturn.transform.localRotation;
    }

    public void ReturnToTarget() {
        TargetToReturn.transform.localPosition = positionToTransform;
        TargetToReturn.transform.localRotation = rotationToTranform;
    }
}
