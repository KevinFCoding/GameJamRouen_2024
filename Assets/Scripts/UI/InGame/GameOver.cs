using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField] GameObject _gameOverCanvas;
    [SerializeField] GameManager _gameManager;

    [SerializeField] List<SpriteRenderer> _MontSaintStates;
    [SerializeField] Image _finalStateMSMToDisplay;
    [SerializeField] List<GameObject> _whoWon;

    private void Start()
    {
        foreach (GameObject go in _whoWon)
        {
            go.SetActive(false);
        }
    }
    public void ShowScoreBoard()
    {
        _gameOverCanvas.SetActive(true);
        _finalStateMSMToDisplay.sprite = _MontSaintStates[_gameManager.getMsMFinalState()].sprite;
        bool whoWasAttacking = _gameManager.getStatusAttack(); // if false bretagne attack

        if(!whoWasAttacking && _gameManager.getIsMontSaintMichelDead())
        {
            _whoWon[0].SetActive(true); // bretagne atq
        }
        else if (!whoWasAttacking && !_gameManager.getIsMontSaintMichelDead())
        {
            _whoWon[1].SetActive(true); // bretagne atq
        }
        else if (whoWasAttacking && _gameManager.getIsMontSaintMichelDead())
        {
            _whoWon[1].SetActive(true); // normandie atq / 
        }
        else if (whoWasAttacking && !_gameManager.getIsMontSaintMichelDead())
        {
            _whoWon[0].SetActive(true); // normandie atq 
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        _gameManager.gameIsFinished = false;
    }




}
