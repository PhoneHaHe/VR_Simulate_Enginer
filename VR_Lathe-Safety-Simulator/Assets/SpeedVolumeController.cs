using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedVolumeController : MonoBehaviour
{
    public static int minRateSpeed { get; set; } = 54;
    public static int MaxRateSpeed { get; set; } = 215;

    public Transform[] target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        SetThisToCorrectSnappoint();
    }

    void SetThisToCorrectSnappoint() {

            transform.LookAt(target[0]);
        
    }

    void SetSpeedRateMinToMax() { 
        
    }
}
