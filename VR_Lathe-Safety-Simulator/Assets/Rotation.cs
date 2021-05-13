﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedRate = 10f;
    public float direction = 1f;
    public bool rotateIsActive = false;

    public bool rotationByPositiveBool = false;
    public bool rotationByNegativeBool = false;

    private ButtonStrucer button;
    void Start()
    {
        button = GameObject.Find("Green_button1").GetComponent<ButtonStrucer>();
        rotateIsActive = button.isActivate;
    }

    // Update is called once per frame
    void Update()
    {
        rotateIsActive = button.isActivate;

        if (rotateIsActive == true)
        {
            if (rotationByPositiveBool)
            {
                rotationByPositiveValue();
            }
            else if (rotationByNegativeBool)
            {
                rotationByNegativeValue();
            }
        }

    }

    void FixedUpdate()
    {

    }


    public void rotationByPositiveValue()
    {

        Debug.Log("rotationByPositiveValue isCall ");
        if (rotateIsActive)
        {
            var speed = new Vector3(speedRate * direction, 0f, 0f);
            transform.Rotate(speed);
        }

    }

    public void rotationByNegativeValue()
    {
        Debug.Log("rotationByNegativeValue isCall ");
        if (rotateIsActive)
        {
            var speed = new Vector3(speedRate * -direction, 0f, 0f);
            transform.Rotate(speed);
        }
    }
}
