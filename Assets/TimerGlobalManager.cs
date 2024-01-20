using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerGlobalManager : MonoBehaviour
{

    [SerializeField] bool isGameFinished;
    public float seconds;
    private bool isRunning = false;
    public TMP_Text scoreText;


 
    void Start()
    {
        seconds = 180;
    }
    void Update()
    {
        if (isRunning && isGameFinished == false)
        {
            IncreaseTimer();
        }
    }

    void StartTimer()
    {
        isRunning = true;
    }

    void IncreaseTimer()
    {
        seconds -= Time.deltaTime;
        scoreText.text = seconds.ToString();
        float minute = Mathf.FloorToInt(seconds / 60);
        float sec = Mathf.FloorToInt(seconds % 60);
        if (sec < 10)
        {
            scoreText.text = minute + " :0" + sec.ToString();
        }
        else
        {
            scoreText.text = minute + " : " + sec.ToString();
        }
    }
    


}