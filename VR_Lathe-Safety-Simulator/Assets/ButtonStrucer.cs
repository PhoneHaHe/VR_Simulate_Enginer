using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStrucer : MonoBehaviour
{

    public bool isActivate = false;
    public bool buttonHit = false;
    private GameObject button;
    public GameObject lighyObj;

    private float buttonReturnToDistance = 0.0025f;
    private float buttonReturnSpeed = 0.0001f;
    private float buttonOrigin;
    private Light buttonLight;

    private float buttonCanHitAgainTime = 0.5f;
    private float canHitAgain;
    // Start is called before the first frame update
    void Start()
    {
        buttonLight = lighyObj.GetComponent<Light>();

        if (buttonLight != null)
        {
            buttonLight.enabled = !buttonLight.enabled;
            Debug.Log("buttonLight is off");
        }

        button = transform.GetChild(0).gameObject;
        buttonOrigin = button.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        TryAccessToButton();
    }

    void FixedUpdate()
    {
        TryAccessToButton();
    }

    private void TryAccessToButton()
    {
        if (buttonHit == true)
        {

            buttonHit = false;

            isActivate = !isActivate;

            button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - buttonReturnToDistance, button.transform.position.z);

            if (isActivate)
            {
                buttonLight.enabled = true;
            }
            else
            {
                buttonLight.enabled = false;
            }
        }

        if (button.transform.position.y < buttonOrigin)
        {
            button.transform.position += new Vector3(0, buttonReturnSpeed, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Tracking Something ");

        if (other.CompareTag("HandPlayer") && canHitAgain < Time.time)
        {
            Debug.Log("HandPlayer Tracking");
            canHitAgain = Time.time + buttonCanHitAgainTime;
            buttonHit = true;
        }
    }

    
}
