using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] GameManager _gameManager;
    public bool _isBretonDefend;
    [SerializeField] AudioSource _source;
    [SerializeField] List<AudioClip> _clips;
    [SerializeField] TimerGlobalManager _timerGlobalManager;
    void Start()
    {
        ChangeMusic();
    }

    void Update()
    {
        if(_timerGlobalManager.seconds <= 10)
        {
            _source.pitch = 1.16f;
        }
    }

    public void ChangeMusic()
    {
        if (_isBretonDefend)
        {
            _source.clip = _clips[1];
            _source.loop = true;
            _source.Play();
        }
        else
        {
            _source.clip = _clips[0];
            _source.loop = true;
            _source.Play();
        }
    }
}
