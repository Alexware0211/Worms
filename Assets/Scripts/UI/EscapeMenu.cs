using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public bool pauseGame;
    public GameObject escapeUI;

    void Start()
    {
        escapeUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;

            if (pauseGame)
            {
                Time.timeScale = 0f;
                escapeUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1f;
                escapeUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game..");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ResumeGame()
    {
        escapeUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
