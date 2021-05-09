using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Vector3 currentPositionOfPlatform;
    public float currentEulerAngles = 0;
    public float MaxPosition = 3.429f;
    public float MinPosition = 2.347f;
    void Start()
    {
        currentPositionOfPlatform = target.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateRotationOfValve();

        if (currentEulerAngles < 0 && currentPositionOfPlatform.x >= MinPosition)//Left
        {
            target.transform.position = target.transform.position + new Vector3(currentEulerAngles / 100, 0, 0) * Time.deltaTime;
        }
        else if (currentEulerAngles > 0 && currentPositionOfPlatform.x <= MaxPosition)//Right
        {
            target.transform.position = target.transform.position + new Vector3(currentEulerAngles / 100, 0, 0) * Time.deltaTime;
        }

    }

    public void updateRotationOfValve(){

        var turn = transform.localEulerAngles.z; 
        turn = (turn > 180) ? turn - 360 : turn;
        currentEulerAngles = turn;
        currentPositionOfPlatform = target.transform.position;
    }


}
