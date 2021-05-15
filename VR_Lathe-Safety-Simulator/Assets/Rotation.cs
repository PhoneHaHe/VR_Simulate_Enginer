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

    private GameObject lightObject;
    private Light _light;
    private Renderer _originColorBoard;

    public AudioSource chuckSound2;
    public AudioSource alert;
    void Start()
    {
        button = GameObject.Find("Green_button1").GetComponent<ButtonStrucer>();
        rotateIsActive = button.isActivate;

        lightObject = transform.GetChild(1).gameObject;
        _light = lightObject.GetComponent<Light>();
        _light.enabled = false;

        
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
                chuckSound2.Play();

            }
            else if (rotationByNegativeBool)
            {
                rotationByNegativeValue();
            }
            
        }
        if (rotateIsActive == false)
        {
            chuckSound2.Stop();
        }
            

    }

    void FixedUpdate()
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


    public void rotationByPositiveValue()
    {

        /*Debug.Log("rotationByPositiveValue isCall ");*/
        if (rotateIsActive)
        {
            var speed = new Vector3(speedRate * direction, 0f, 0f);
            transform.Rotate(speed);
        }

        // rotationByPositiveBool = true;

    }

    public void rotationByNegativeValue()
    {
        /*Debug.Log("rotationByNegativeValue isCall ");*/
        if (rotateIsActive)
        {
            var speed = new Vector3(speedRate * -direction, 0f, 0f);
            transform.Rotate(speed);
        }

        // rotationByNegativeBool = true;
    }

    public void isSwitchSelectPositive()
    {
        rotationByPositiveBool = true;
        rotationByNegativeBool = false;
    }

    public void isSwitchSelectNegative()
    {
        rotationByPositiveBool = false;
        rotationByNegativeBool = true;

    }

    public void isSwitchSelectNone()
    {
        rotationByPositiveBool = false;
        rotationByNegativeBool = false;
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Tracking Something ");

        if (other.CompareTag("HandPlayer"))
        {

            if (rotateIsActive == true) {
                Debug.LogError("HandPlayer Tracking " + "Hand Dramage");
                _light.enabled = true;
                alert.Play();


            } 
        }
    }

    void OnTriggerExit(Collider other) {


        if (other.CompareTag("HandPlayer")) {
            _light.enabled = false;
            alert.Stop();
        }

    }

}
