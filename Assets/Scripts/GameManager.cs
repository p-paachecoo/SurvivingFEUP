using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject aboutUI;
    public GameObject instructionsUI;
    public GameObject mainMenuUI;

    void Start()
    {
        Time.timeScale = 0f;
        MainMenu();
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        mainMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Play()
    {
        Time.timeScale = 1f;
        mainMenuUI.SetActive(false);
    }

    public void MainMenu()
    {
        aboutUI.SetActive(false);
        instructionsUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void About()
    {
        mainMenuUI.SetActive(false);
        instructionsUI.SetActive(false);
        aboutUI.SetActive(true);
    }

    public void Instructions()
    {
        mainMenuUI.SetActive(false);
        aboutUI.SetActive(false);
        instructionsUI.SetActive(true);
    }
}
