using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private float startVolume = 0.2f;
    [SerializeField] private float increaseVolumeBy = 0.0001f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
        audioSource.volume = startVolume;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(audioSource.volume < 0.2)
        {
            audioSource.volume += increaseVolumeBy;
        }
        
    }
}
