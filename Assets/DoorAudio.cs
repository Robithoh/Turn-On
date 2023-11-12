using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudio : MonoBehaviour
{

    public AudioClip doorAudio;
    AudioSource DoorSound;

    // Start is called before the first frame update
    void Start()
    {
        DoorSound = GetComponent<AudioSource>();
    }

    public void door()
    {
        DoorSound.clip = doorAudio;
        DoorSound.Play();
    }

    
}
