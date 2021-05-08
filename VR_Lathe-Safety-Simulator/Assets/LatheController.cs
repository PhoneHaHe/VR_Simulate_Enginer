using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatheController : MonoBehaviour
{
    public GameObject lathePlatform;
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        updatePositionOfPlatform();
    }

    void FixedUpdate(){
        updatePositionOfPlatform();
    }

    public void MovetoLeft(){
        lathePlatform.transform.Translate(new Vector3(10,0,0));
    }

    public void MovetoRight(){
        lathePlatform.transform.Translate(new Vector3(10,0,0));
    }

    public void updatePositionOfPlatform(){
        position = lathePlatform.transform.position;
    }
}
