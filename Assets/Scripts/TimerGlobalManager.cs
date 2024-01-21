using TMPro;
using UnityEngine;

public class TimerGlobalManager : MonoBehaviour
{

    [SerializeField] bool isGameFinished;
    [SerializeField] float setupTime;
    public float seconds;
    [SerializeField] bool isRunning = false;
    public TMP_Text scoreText;


    void Update()
    {
        if (isRunning)
        {
            IncreaseTimer();
        }

        if(seconds <= 0)
        {
            seconds = 0;
            scoreText.text = "00:00";
        }
    }

    public void StartTimer()
    {
        seconds = setupTime;
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

    public void StopTimer()
    {
        isRunning = false;
    }



}
