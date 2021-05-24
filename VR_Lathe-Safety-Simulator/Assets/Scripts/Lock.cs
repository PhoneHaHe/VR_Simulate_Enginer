using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    [SerializeField] private LockObjects _Lo;
    public bool isTrigger = false;
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Interect With Something");
        if (other.CompareTag("TargetWork"))
        {
            Debug.Log("Interect With Target");
            
                isTrigger = true;

        }
    }

}
