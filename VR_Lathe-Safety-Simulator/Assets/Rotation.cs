using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
public  float speedRate = 1f;
public float direction = 1f;
public bool rotateIsActive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rotateIsActive)
        rotationByValue();
    }


    void rotationByValue(){
        var speed = new Vector3(speedRate * direction,0f,0f);
        transform.Rotate(speed);
    }
}
