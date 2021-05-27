using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushRemove : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        Debug.Log($"{other.name}");

        if (other.CompareTag("Scraps")) {

            other.gameObject.SetActive(false);
        }
    }


}
