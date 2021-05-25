using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource coinAudioClip;


    public void CoinAudio()
    {
        coinAudioClip.Play();
    }

}
