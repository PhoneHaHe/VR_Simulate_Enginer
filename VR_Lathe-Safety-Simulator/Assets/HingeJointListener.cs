using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HingeJointListener : MonoBehaviour
{
    //angle threshold to trigger if we reached limit
    public float angleBetweenThreshold = 1f;
    //State of the hinge joint : either reached min or max or none if in between
    public HingeJointState hingeJointState = HingeJointState.None;

    //Event called on min reached
    public UnityEvent OnMinLimitReached;
    //Event called on max reached
    public UnityEvent OnMaxLimitReached;

    public UnityEvent OnNoneReached;

    public enum HingeJointState { Min,Max,None}
    private HingeJoint hinge;


    //Target 
    public GameObject targetObject;
    private Rotation rotateObject;
    private float speedRate = 1f;
    private float directionRotate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        rotateObject = targetObject.GetComponent<Rotation>();
        Debug.Log("Max: " + hinge.limits.max);
        Debug.Log("Min: " + hinge.limits.min);

    }

    private void FixedUpdate()
    {
        float angleWithMinLimit = Mathf.Abs(hinge.angle - hinge.limits.min);
        float angleWithMaxLimit = Mathf.Abs(hinge.angle - hinge.limits.max);

        /*Debug.Log("angleWithMinLimit " + angleWithMinLimit);
        Debug.Log("angleWithMaxLimit " + angleWithMaxLimit);*/

        //Reached Min
        if(angleWithMinLimit < angleBetweenThreshold)
        {
            if (hingeJointState != HingeJointState.Min)
                OnMinLimitReached.Invoke();

            hingeJointState = HingeJointState.Min;
        }
        //Reached Max
        else if (angleWithMaxLimit < angleBetweenThreshold)
        {
            if (hingeJointState != HingeJointState.Max)
                OnMaxLimitReached.Invoke();


            hingeJointState = HingeJointState.Max;
        }
        //No Limit reached
        else
        {
            hingeJointState = HingeJointState.None;
            if(hingeJointState == HingeJointState.None){
                OnNoneReached.Invoke();
            }
        }
    }

}
