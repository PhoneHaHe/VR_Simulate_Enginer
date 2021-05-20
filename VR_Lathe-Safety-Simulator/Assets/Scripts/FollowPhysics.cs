using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 owe_position;
    public Quaternion owe_rotate;
    public bool isSet { get; set; } = true;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(target.transform.position);
        if (isSet)
        {
            SetPosition();
            if (target.position == owe_position && target.rotation == owe_rotate) {

              isSet = false;
                Debug.LogError(target.transform.position);
                Debug.LogError(target.transform.rotation);
            }
        }
    }

    public void SetPosition() {
        
        target.localPosition = owe_position;
        target.localRotation = owe_rotate;
    }
}
