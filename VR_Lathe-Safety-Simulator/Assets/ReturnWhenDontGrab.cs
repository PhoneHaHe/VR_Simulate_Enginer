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
            positionToTransform = TargetToReturn.transform.position;
            rotationToTranform = TargetToReturn.transform.rotation;
    }

    public void ReturnToTarget() {
        TargetToReturn.transform.position = positionToTransform;
        TargetToReturn.transform.rotation = rotationToTranform;
    }
}
