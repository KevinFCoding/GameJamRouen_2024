using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] River _river;
    [SerializeField] TimerManager _timer;
    [SerializeField] int _roundSeconds;
    [SerializeField] bool _statusAttack;

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
        _roundSeconds = Random.RandomRange(10, 20);
        _timer.seconds = _roundSeconds;

    }

    public bool getStatusAttack()
    {
        return _statusAttack;
    }
}
