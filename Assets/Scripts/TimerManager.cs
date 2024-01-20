using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerManager : MonoBehaviour
{

    public float seconds;
    private bool _isRunning = false;
    [SerializeField] GameManager _gameManager;
    public bool isFinishTimer;
 


    private void Awake()
    {
    }
    void Start()
    {
    }
    void Update()
    {
       
            IncreaseTimer();
        
    }

  
    public void IncreaseTimer()
    {
        seconds -= Time.deltaTime;
        if(seconds <= 0)
        {
            isFinishTimer = true;
            _gameManager.SetUpTimer();

        }
    }


}
