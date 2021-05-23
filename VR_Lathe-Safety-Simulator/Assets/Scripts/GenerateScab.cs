using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateScab : MonoBehaviour
{

    bool isTruch = false;
    bool isOnSelect = false;
    [SerializeField] private Transform effect;
    [SerializeField] private Transform _effaceParent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpeawnerEffect();
    }

    private void FixedUpdate()
    {

        SpeawnerEffect();

    }


    private void SpeawnerEffect()
    {
        if (isOnSelect)
        {
            if (isTruch)
            {
                Transform _effectS = Instantiate(effect);
                _effectS.SetParent(_effaceParent);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Blade"))
        {
            isTruch = true;

            SpeawnerEffect();

        }
    }

    private void OnTriggerExit(Collider other)
    {

        isTruch = true;

    }
}
