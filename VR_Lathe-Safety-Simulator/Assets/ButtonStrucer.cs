using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStrucer : MonoBehaviour
{   

    public bool isActivate;
    public GameObject Button;
    public GameObject LighyObj;
    private Light buttonLight;
    // Start is called before the first frame update
    void Start()
    {
      buttonLight = LighyObj.GetComponent<Light>();

      if(buttonLight != null){
          buttonLight.enabled = !buttonLight.enabled;
          Debug.Log("0000");
      }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
