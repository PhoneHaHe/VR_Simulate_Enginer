using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedVolumeController : MonoBehaviour
{
    public static int MinRateSpeed { get; set; } = 0;
    public static int MaxRateSpeed { get; set; } = 0;

    [SerializeField] GameObject TargetToReturn;
    Vector3 positionToTransform;
    Quaternion rotationToTranform;

    private Collider Arrow;

    
    // Start is called before the first frame update
    void Start()
    {
        Arrow = transform.GetChild(1).GetComponent<Collider>();
        positionToTransform = TargetToReturn.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other != null)
     {
            
            if (other.name == "A")
            {
                MinRateSpeed = 54;
                MaxRateSpeed = 215;
            }
            else if (other.name == "B")
            {
                MinRateSpeed = 214;
                MaxRateSpeed = 975;
            }
            else if (other.name == "C")
            {
                MinRateSpeed = 750;
                MaxRateSpeed = 3000;
            }
            

            Debug.Log($"{MinRateSpeed}, {MaxRateSpeed}");
        }
    }

    private void OnTriggerExit(Collider other) {
        
    }

    public void SetPosition()
    {

        transform.position = positionToTransform;
    }

}
