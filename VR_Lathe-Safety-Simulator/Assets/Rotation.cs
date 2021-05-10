using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
public  float speedRate = 1f;
public bool isActive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isActive)
        transform.Rotate(new Vector3(speedRate,0f,0f));
    }
}
