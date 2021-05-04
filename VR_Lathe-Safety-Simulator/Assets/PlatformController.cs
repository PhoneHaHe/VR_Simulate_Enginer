using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlatformController : MonoBehaviour
{
    
    public GameObject platform;
    public GameObject valveSwitch;

    public Vector3 positionPlatform;

    public float speed = 2;

    private InputDevice targetDevices;
    // Start is called before the first frame update
    void Start()
    {
        positionPlatform = platform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToTheLeft(){
        Debug.Log("MoveToTheLeft");
        platform.transform.position = platform.transform.position + new Vector3(-speed * Time.deltaTime,0,0);
    }

    public void MoveToTheRight(){
        Debug.Log("MoveToTheRight");
        platform.transform.position = platform.transform.position + new Vector3(speed * Time.deltaTime,0,0);
    }
}
