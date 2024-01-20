using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] GameObject _gameOverCanvas;
    [SerializeField] GameManager _gameManager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowScoreBoard()
    {
        _gameOverCanvas.SetActive(true);
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
