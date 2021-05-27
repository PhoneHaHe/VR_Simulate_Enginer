using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStatusTools : MonoBehaviour
{

    [SerializeField] private List<Transform> _StatusBarOfTools;
    [SerializeField] private Material _ToThisMaterial;

    public void UpdateStatusBar(int other) {

        if (_StatusBarOfTools != null) {

            var _StatusBar = _StatusBarOfTools[other].transform.GetComponent<Renderer>();

            _StatusBar.material = _ToThisMaterial;
        
        }
    }
}
