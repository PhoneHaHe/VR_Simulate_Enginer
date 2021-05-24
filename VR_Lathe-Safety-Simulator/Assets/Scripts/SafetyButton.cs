using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyButton : MonoBehaviour
{
    public bool isSafeActivate = false;
    public bool buttonSafeHit = false;
    private GameObject button;
    private float buttonReturnToDistanceY = 0.0044f;
    private float buttonReturnSpeed = 0.0001f;
    private float buttonOriginY;
    private float buttonOriginZ;


    [SerializeField] private Transform _ObjectRotate;
    private Rotation _rotateObject;


    //delay for hit
    private float buttonCanHitAgainTime = 0.5f;
    private float canHitAgain;

    //ref to Main Button
    private ButtonStrucer buttonMain;
    // Start is called before the first frame update
    public AudioSource click;
    void Start()
    {
        button = transform.GetChild(0).gameObject;
        buttonOriginY = button.transform.position.y;
        buttonOriginZ = button.transform.position.z;
        _rotateObject = _ObjectRotate.gameObject.GetComponent<Rotation>();

        buttonMain = GameObject.Find("Green_button1").GetComponent<ButtonStrucer>();
    }

    // Update is called once per frame
    void Update()
    {
        TryAccessToButton();
    }

    void FixedUpdate() {
        TryAccessToButton();
    }

    private void TryAccessToButton()
    {
        if (buttonSafeHit == true)
        {

            buttonSafeHit = false;

            isSafeActivate = !isSafeActivate;

            button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - buttonReturnToDistanceY, button.transform.position.z);
            _rotateObject.ShuckdownSound();

            safetyActivate();
            click.Play();

        }

        if (button.transform.position.y < buttonOriginY)
        {
            button.transform.position += new Vector3(0, buttonReturnSpeed, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Tracking Something ");

        if (other.CompareTag("HandPlayer") && canHitAgain < Time.time)
        {
            Debug.Log("HandPlayer Tracking");
            canHitAgain = Time.time + buttonCanHitAgainTime;
            buttonSafeHit = true;

        }
    }

    void safetyActivate(){
        Debug.Log("Safe Action isCall");

        buttonMain.OnSafetyCall();
        isSafeActivate = !isSafeActivate;
    }
}
