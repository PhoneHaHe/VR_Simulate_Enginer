using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatateTarget : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _TransformTargetRotation;

    public bool TriggerOnPosition { get; set; } = false;
    public bool OnTriggerRotate { get; set; } = false;

    private bool rotating = true;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rotateToActionPosition();
    }

    public void rotateToActionPosition() {

        
    }
}
