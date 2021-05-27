using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateScab : MonoBehaviour
{

    public bool isTruch = false;
    public bool isOnSelect { get; set; } = false;
    [SerializeField] private Transform effect;
    [SerializeField] private List<Transform> _TargetEffect;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private Rotation _currentRotation;
    // Start is called before the first frame update
    void Start()
    {
        _currentRotation = GameObject.Find("ChuckLathe").GetComponent<Rotation>();
        effect.gameObject.GetComponent<Rigidbody>().useGravity = false;
        effect.gameObject.SetActive(false);
        for (int i = 0; i < _TargetEffect.Count; i++) {

            _TargetEffect[i].gameObject.SetActive(false);
        }

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
            if (_currentRotation.rotationByNegativeBool || _currentRotation.rotationByPositiveBool)
            {
                if (isTruch)
                {

                    // Transform _effectS = Instantiate(effect);
                    // _effectS.SetParent(_effaceParent);
                    // _effectS.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    effect.gameObject.SetActive(true);
                    for (int i = 0; i < _TargetEffect.Count; i++)
                    {

                        _TargetEffect[i].gameObject.SetActive(true);
                    }
                    _audioSource.PlayOneShot(_audioClip);

                }

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Interect With Something");
        if (other.CompareTag("TargetWork"))
        {
            Debug.Log("Interect With Target");
            isTruch = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("TargetWork"))
        {
            Debug.Log("OnTriggerExit With Target");
            isTruch = false;

        }

        effect.gameObject.SetActive(false);

    }
}
