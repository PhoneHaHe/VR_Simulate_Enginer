using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatheController : MonoBehaviour
{
    public GameObject lathePlatform;
    public Vector3 position;

    public bool isActive = false;

    public bool isLeft;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updatePositionOfPlatform();

        if (isLeft)
        {
            MovetoLeft();
        }

        if (isRight)
        {
            MovetoRight();
        }
    }

    void FixedUpdate()
    {
        updatePositionOfPlatform();

        if (isLeft)
        {
            MovetoLeft();
        }

        if (isRight)
        {
            MovetoRight();
        }
    }

    public void MovetoLeft()
    {
        lathePlatform.transform.Translate(new Vector3(0.001f , 0, 0));

        // isLeft = false;
    }

    public void MovetoRight()
    {
        lathePlatform.transform.Translate(new Vector3(-0.001f, 0, 0));

        // isRight = false;
    }

    public void updatePositionOfPlatform()
    {
        position = lathePlatform.transform.position;
    }
}
