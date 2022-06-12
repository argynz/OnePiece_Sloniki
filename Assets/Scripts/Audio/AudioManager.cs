using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgAudioMedieval;
    public AudioSource bgAudioDanger;
    public AudioSource getDamageAudio;
    public AudioSource clickAudio;
    public AudioSource notificationAudio;
    public AudioSource dialogueAudio;

    void Start()
    {
        bgAudioMedieval.Play();
    }

    void Update()
    {
        
    }
}
