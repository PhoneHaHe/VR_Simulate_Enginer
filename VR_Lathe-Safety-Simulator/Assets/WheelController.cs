using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WheelController : MonoBehaviour
{
    // Object Target to management move
    public GameObject target;
    public Vector3 currentPositionOfPlatform;
    public float currentEulerAngles = 0;
    public float MaxPosition;
    public float MinPosition;
    void Start()
    {
        currentPositionOfPlatform = target.transform.position;
        updateRotationOfValve();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateRotationOfValve();

        if (currentEulerAngles < 0 && currentPositionOfPlatform.x >= MinPosition)//Left
        {
            movePlatformByEulerAngles();
        }
        else if (currentEulerAngles > 0 && currentPositionOfPlatform.x <= MaxPosition)//Right
        {
            movePlatformByEulerAngles();
        }

    }

    public void updateRotationOfValve()
    {

        var turn = transform.localEulerAngles.z;
        turn = (turn > 180) ? turn - 360 : turn;  

        currentEulerAngles = turn;
        currentPositionOfPlatform = target.transform.position;
    }

    private void movePlatformByEulerAngles()
    {
        var speedRate = new Vector3(currentEulerAngles / 100, 0, 0);
        target.transform.position = target.transform.position + speedRate * Time.deltaTime;
    }

    /*void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tracking Something ");

        if (other.CompareTag("HandPlayer") *//*&& canHitAgain < Time.time*//*)
        {
            Debug.Log("HandPlayer Tracking");
            *//*canHitAgain = Time.time + buttonCanHitAgainTime;
            buttonHit = true;*/
            /*var speedRate = new Vector3(currentEulerAngles / 100, 0, 0);
            target.transform.position += target.transform.position + speedRate * Time.deltaTime;*//*
        }
    }*/


}
