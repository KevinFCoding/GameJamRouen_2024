using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    public AudioClip[] songs;
    public float volume;

    private void Start()
    {
        _audioSource.clip = songs[0];
    }
    private void Update()
    {

        PlayOtherMusic();
    }

    private void PlayOtherMusic()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = songs[1];
            _audioSource.loop = true;
            _audioSource.Play();
        }
    }
}
