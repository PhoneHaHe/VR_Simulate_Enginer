using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public Quaternion ownAxis = Quaternion.identity;
    void Start()
    {
        ownAxis = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (ownAxis.z > 0)
        {
            target.transform.position = target.transform.position + new Vector3(1, 0, 0) * Time.deltaTime;
        }
        else if (ownAxis.z < 0)
        {
            target.transform.position = target.transform.position + -new Vector3(1, 0, 0) * Time.deltaTime;
        }else {
            target.transform.position = target.transform.position + -new Vector3(0, 0, 0) * Time.deltaTime;
        }
    }
}
