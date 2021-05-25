using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockObjects : MonoBehaviour
{

    [SerializeField] private List<Transform> _Legs;
    [SerializeField] private Transform _Target;

    [SerializeField] private List<Transform> LegsPointReturn;

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
        for (int i = 0; i < _Legs.Count; i++)
        {
            _OriginPosition.Add(new Vector3(_Legs[i].transform.position.x, _Legs[i].transform.position.y, _Legs[i].transform.position.z));
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
                _Legs[0].transform.position = Vector3.MoveTowards(_Legs[0].transform.position, LegsPointReturn[0].position, step);
                _Legs[1].transform.position = Vector3.MoveTowards(_Legs[1].transform.position, LegsPointReturn[1].position, step);
                _Legs[2].transform.position = Vector3.MoveTowards(_Legs[2].transform.position, LegsPointReturn[2].position, step);

                

                if (Vector3.Distance(_Legs[0].transform.position, LegsPointReturn[0].transform.position) == 0f
                    && Vector3.Distance(_Legs[1].transform.position, LegsPointReturn[1].transform.position) == 0f
                    && Vector3.Distance(_Legs[2].transform.position, LegsPointReturn[2].transform.position) == 0f)
                {
                    for (int i = 0; i < _Legs.Count; i++)
                    {
                        _Legs[i].GetComponent<Lock>().isTrigger = false;
                    }

                    onLockObject = false;
                    TurnUnLock = false;
                }
                else { 
                
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
