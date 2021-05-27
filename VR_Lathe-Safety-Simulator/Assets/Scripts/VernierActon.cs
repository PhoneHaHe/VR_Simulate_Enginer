using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VernierActon : MonoBehaviour
{

    [SerializeField] Transform _VernierHead;
    [SerializeField] Transform _VernierMonth;
    [SerializeField] Canvas _VernierCanvas;
    [SerializeField] Transform _TargetOn;

    private Vector3 _standbyPosition;
    private bool isNear = false;
    private float speed = 1f;
    [SerializeField] private Text _state;
    // Start is called before the first frame update

    void SetUp() {

        if (_VernierHead == null && _VernierMonth == null) {

            _VernierHead = gameObject.transform.Find("SchieberCenter").GetComponent<Transform>();
            _VernierMonth = gameObject.transform.Find("Schieber").GetComponent<Transform>();
        }

        _VernierCanvas.gameObject.SetActive(false);

        _standbyPosition = _VernierMonth.localPosition + new Vector3(-1.3f, 0, 0);
    }


    void Start()
    {
        SetUp();
    }

    public void StandByToCalculate() {

        if (_VernierMonth.localPosition == Vector3.zero) {
            _VernierMonth.localPosition = _standbyPosition;
        }

    }

    public void MoveVannierToTarget() {

        if (!isNear) {

            float step = speed * Time.deltaTime; // calculate distance to move
            _VernierMonth.transform.localPosition = Vector3.MoveTowards(_VernierMonth.transform.localPosition, _TargetOn.localPosition, step);

        }
        
    }

    public void UpdateText() {
        _VernierCanvas.gameObject.SetActive(true);

        Debug.Log($"{_state.text}");

        _state.text = " 101 mm.";
    }

    public void ResetText()
    {

        Debug.Log($"{_state.text}");

        _state.text = " ___ mm.";
    }

    public void Reset()
    {

        _VernierMonth.localPosition = Vector3.zero;

        ResetText();
    }
}
