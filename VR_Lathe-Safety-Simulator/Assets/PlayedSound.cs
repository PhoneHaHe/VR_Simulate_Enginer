using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayedSound : MonoBehaviour

{

    public AudioClip _Guardclose;
    public AudioClip _GuardOpen;

    AudioSource source;

    void Start() {
        source = gameObject.AddComponent<AudioSource>();
    }
    

    public void WhenOpenIt()
    {
        source.PlayOneShot(_GuardOpen);
    }

    
    public void WhenCloseIt()
    {
        source.PlayOneShot(_Guardclose);
    }
}
