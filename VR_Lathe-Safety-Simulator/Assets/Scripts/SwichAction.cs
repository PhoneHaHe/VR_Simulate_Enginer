using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwichAction : MonoBehaviour
{
    public void RestartScene() {

        SceneManager.LoadScene("Oculus_Ml", LoadSceneMode.Single);
    }
}
