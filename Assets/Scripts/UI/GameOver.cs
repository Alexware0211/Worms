using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [Header("UI Elements")]
    public Text victoryScreen;

    public void GameOverText(int Player)
    {
        if (Player == 1)
        {
            victoryScreen.text = "Player 1 Wins!";
            victoryScreen.color = Color.red;
        }
        else if (Player == 2)
        {
            victoryScreen.text = "Player 2 Wins!";
            victoryScreen.color = Color.blue;
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ReMatch()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

}
