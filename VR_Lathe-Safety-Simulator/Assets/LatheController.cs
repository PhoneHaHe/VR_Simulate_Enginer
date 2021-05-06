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
        // lathePlatform.transform.Translate();
    }

    public void MovetoRight(){
        
    }

    public void updatePositionOfPlatform(){
        position = lathePlatform.transform.position;
    }
}
