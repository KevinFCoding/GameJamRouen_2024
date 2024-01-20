using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] River _river;
    [SerializeField] TimerManager _timer;
    [SerializeField] int _roundSeconds;

    void Start()
    {
        SetUpTimer();
    }

    void Update()
    {
        if (_timer.isFinishTimer)
        {
           //SwitchAttack();
            print("SWITCH");
            _timer.isFinishTimer = false;

        }
    }

    public void SwitchAttack()
    {
        _river.ChangeState();
    }

    public void SetUpTimer()
    {
        _roundSeconds = Random.RandomRange(10, 20);
        _timer.seconds = _roundSeconds;

    }
}
