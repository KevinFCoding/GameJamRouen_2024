using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] River _river;
    [SerializeField] TimerManager _timer;
    [SerializeField] TimerGlobalManager _timerGlobal;
    [SerializeField] TargetLife _target;
    [SerializeField] GameOver _gameOver;
    [SerializeField] int _roundSeconds;
    [SerializeField] bool _statusAttack;
    public bool gameIsFinished;
    [SerializeField] Animator _animRiver;

    [SerializeField] AudioManager _audiomanager;
    [SerializeField] AudioClip _swap;
    [SerializeField] AudioClip _rain;

    [SerializeField] ParticleSystem _rainPartSysteme;

    private bool isMontSaintMichelDead = false;
    private bool isRainFalling = false;

    private int MsMState = 0;

    void Start()
    {
        PrepareStartGame();
        MsMState = 0; // Used for endGame
        isMontSaintMichelDead = false; // Used for endGame
    }

    public void PrepareStartGame()
    {
        SetUpTimer();
        _timerGlobal.StartTimer();
        gameIsFinished = false;
    }

    void Update()
    {
        if (_timer.isFinishTimer)
        {
            _rainPartSysteme.Stop();

            SwitchAttack();
            _timer.isFinishTimer = false;
            _animRiver.enabled = false;
        }

        if (_target.currentHP <= 0)
        {
            isMontSaintMichelDead = true;
            GameOver();
        }

        if(_timer.seconds <= 3)
        {
            _animRiver.enabled = true;
            if (!isRainFalling)
            {
                _audiomanager.GetComponent<AudioSource>().PlayOneShot(_rain);
                _rainPartSysteme.Play();
                isRainFalling = true;
            }
        }

        if (_timerGlobal.seconds <= 0) {
            GameOver();
        }
    }

    public void SwitchAttack()
    {
        isRainFalling = false;
        if (_statusAttack == true) // if true then the bretagne is attacking
        {
            _statusAttack = false;
            _river._currentState = _statusAttack;
            _audiomanager._isBretonDefend = false;
            _audiomanager.ChangeMusic();
        }
        else
        {
            _statusAttack = true;
            _river._currentState = _statusAttack;
            _audiomanager._isBretonDefend = true;
            _audiomanager.ChangeMusic();
        }
        _river.ChangeState();
        _audiomanager.GetComponent<AudioSource>().PlayOneShot(_swap, 2);
    }

    public void SetUpTimer()
    {
        _roundSeconds = Random.Range(10, 21);
        _timer.seconds = _roundSeconds;
        Time.timeScale = 1;

    }

    public bool getStatusAttack()
    {
        return _statusAttack;
    }

    public void GameOver()
    {
        _timerGlobal.StopTimer();
        _timer.StopTimer();
        gameIsFinished = true;
        Time.timeScale = 0;
        _gameOver.ShowScoreBoard();
    }

    public int getMsMFinalState()
    {
        return MsMState;
    }

    public void setMsMFinalState(int index)
    {
        MsMState = index;
    }

    public bool getIsMontSaintMichelDead()
    {
        return isMontSaintMichelDead;
    }



}
