using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{

    [SerializeField] GameObject _credits;
    [SerializeField] GameObject _controls;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LaunchCredits()
    {
        _credits.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CloseCredits()
    {
        _credits.SetActive(false);
    }

    public void ShowControls()
    {
        CloseCredits();
        _controls.gameObject.SetActive(true);
    }
}
