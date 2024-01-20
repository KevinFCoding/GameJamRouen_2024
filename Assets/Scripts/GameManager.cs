using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] River _river;
    [SerializeField] TimerManager _timer;
    [SerializeField] TargetLife _target;
    [SerializeField] GameOver _gameOver;
    [SerializeField] int _roundSeconds;
    [SerializeField] bool _statusAttack;
    public bool gameIsFinished;

    void Start()
    {
        SetUpTimer();
    }

    void Update()
    {
        if (_timer.isFinishTimer)
        {
            SwitchAttack();
            _timer.isFinishTimer = false;


        }

        if (_target.currentHP == 0)
        {
            GameOver();
        }
    }

    public void SwitchAttack()
    {
        if (_statusAttack == true)
        {
            _statusAttack = false;
            _river._currentState = _statusAttack;

        }
        else
        {
            _statusAttack = true;
            _river._currentState = _statusAttack;
        }
        _river.ChangeState();
    }

    public void SetUpTimer()
    {
        _roundSeconds = Random.Range(10, 21);
        _timer.seconds = _roundSeconds;

    }

    public bool getStatusAttack()
    {
        return _statusAttack;
    }

    public void GameOver()
    {
        gameIsFinished = true;
        Time.timeScale = 0;
        _gameOver.ShowScoreBoard();
    }
}
