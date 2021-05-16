using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayedSound : MonoBehaviour

{

    public AudioSource Guardclose;
    

    void PlaySound()
    {
        Guardclose.Play();
    }
}
