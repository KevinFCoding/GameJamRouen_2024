using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    [SerializeField] GameObject _pauseCanvas;
    public bool gameIsPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        _pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;

    }

    public void Resume()
    {
        _pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
}
