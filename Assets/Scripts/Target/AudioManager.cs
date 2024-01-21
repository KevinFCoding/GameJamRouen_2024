using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] GameManager _gameManager;
    [SerializeField] bool _isBretonDefend;
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _bretonMusic;
    [SerializeField] AudioClip _normandMusic;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeMusic()
    {
        if (_isBretonDefend)
        {
           // _source.Play(_normandMusic);
        }
    }
}
