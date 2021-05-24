using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockObjects : MonoBehaviour
{

    [SerializeField] private List<Transform> _Legs;
    [SerializeField] private Transform _Target;

    public UnityEvent OnLock;
    public UnityEvent OnUnlock;

    public List<Vector3> _OriginPosition;
    public float speed = 0.01f;

    public bool onLockObject = false;
    public bool TurnLock = false;
    public bool TurnUnLock = false;
    // Start is called before the first frame update
    void Start()
    {
        _OriginPosition = new List<Vector3>();
        for (int i = 0; i < _Legs.Count; i++) {
            _OriginPosition.Add(_Legs[i].transform.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move


        if (TurnLock)
        {
            if (!onLockObject)
            {
                _Legs[0].transform.position = Vector3.MoveTowards(_Legs[0].transform.position, _Target.position, step);
                _Legs[1].transform.position = Vector3.MoveTowards(_Legs[1].transform.position, _Target.position, step);
                _Legs[2].transform.position = Vector3.MoveTowards(_Legs[2].transform.position, _Target.position, step);

                if (_Legs[0].transform.GetComponent<Lock>().isTrigger == true 
                    && _Legs[1].transform.GetComponent<Lock>().isTrigger == true 
                    && _Legs[2].transform.GetComponent<Lock>().isTrigger == true)
                {
                    onLockObject = true;
                    TurnLock = false;
                }
            }
        }

        if (TurnUnLock) 
        {
            if (onLockObject) 
            { 
                _Legs[0].transform.position = _OriginPosition[0];
                _Legs[1].transform.position = _OriginPosition[1];
                _Legs[2].transform.position = _OriginPosition[2];

                if (_Legs[0].transform.position == _OriginPosition[0]
                    && _Legs[1].transform.position == _OriginPosition[1]
                    && _Legs[2].transform.position == _OriginPosition[2])
                {
                    for (int i = 0; i < _Legs.Count; i++)
                    {
                        _Legs[i].GetComponent<Lock>().isTrigger = false;
                    }

                    onLockObject = false;
                    TurnUnLock = false;
                }
            }

        }

        if (onLockObject == true) {
            OnLock.Invoke();
        }

        if (onLockObject == false)
        {
            OnUnlock.Invoke();
        }
    }


}
