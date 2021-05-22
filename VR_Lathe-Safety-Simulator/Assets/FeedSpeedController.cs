using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FeedSpeedController : MonoBehaviour
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

    public enum HingeJointState { Min, Max, None }
    private HingeJoint hinge;
    public int _minRateSpeed = 0;
    public int _maxRateSpeed = 1;
    public bool _currentRateSpeedMin = false;
    public bool _currentRateSpeedMax = false;

    public static int _currentRateSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        _minRateSpeed = SpeedVolumeController.MinRateSpeed;
        _maxRateSpeed = SpeedVolumeController.MaxRateSpeed;
        Debug.Log("Max: " + hinge.limits.max);
        Debug.Log("Min: " + hinge.limits.min);
    }


    private void FixedUpdate() {
        float angleWithMinLimit = Mathf.Abs(hinge.angle - hinge.limits.min);
        float angleWithMaxLimit = Mathf.Abs(hinge.angle - hinge.limits.max);

        Debug.Log("angleWithMinLimit " + angleWithMinLimit);
        Debug.Log("angleWithMaxLimit " + angleWithMaxLimit);

        //Reached Min
        if (angleWithMinLimit < angleBetweenThreshold)
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
            if (hingeJointState == HingeJointState.None)
            {
                OnNoneReached.Invoke();
            }
        }


        if (_currentRateSpeedMin)
        {
            _currentRateSpeed = 12;
        }
        else if (_currentRateSpeedMax)
        {
            _currentRateSpeed = 100;
        }
        else {
            _currentRateSpeed = 20;
        }
    }

    public void UpdateSpeedRate() {
        Debug.Log($"UpdateSpeedRate {SpeedVolumeController.MinRateSpeed}  {SpeedVolumeController.MaxRateSpeed}");
    
        _minRateSpeed = SpeedVolumeController.MinRateSpeed;
        _maxRateSpeed = SpeedVolumeController.MaxRateSpeed;

        Debug.Log($"UpdateSpeedRate {_minRateSpeed}  {_maxRateSpeed}");
    }

    public void isSwitchSelectPositive()
    {
        _currentRateSpeedMin = true;
        _currentRateSpeedMax = false;
    }

    public void isSwitchSelectNegative()
    {
        _currentRateSpeedMin = false;
        _currentRateSpeedMax = true;

    }

    public void isSwitchSelectNone()
    {
        _currentRateSpeedMin = false;
        _currentRateSpeedMax = false;
    }
}
