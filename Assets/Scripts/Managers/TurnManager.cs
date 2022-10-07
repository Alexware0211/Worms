using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{

    [Header("Timer")]
    public Text timerText;
    public float timeForTimer = 30;

    [Header("Turn Items")]
    public GameObject[] worms;
    public Transform activeWorm;
    public Transform[] wormTransform;

    //Transform for Camera Switching
    Transform Worm1;
    Transform Worm2;


    public void Awake()
    {
        worms = GameObject.FindGameObjectsWithTag("Player");
        worms[1].GetComponent<PlayerController>().enabled = false;

        Worm1 = wormTransform[1];
        Worm2 = wormTransform[0];
        activeWorm = Worm2;
    }

    public void Update()
    {
        timeForTimer -= Time.deltaTime;

        timerText.text =  timeForTimer.ToString("F0") + "s"; // F0 for no digits, F1 for 1, F2 for 2 and so on..


        if (timeForTimer <= 0)
        {
            ResetTimer();
            SwitchTurns();
        }


        if (worms[0].activeInHierarchy == false)
        {
            timeForTimer = 3;
            StartCoroutine("GameOver");
        }
        else if (worms[1].activeInHierarchy == false)
        {
            timeForTimer = 3;
            StartCoroutine("GameOver");
        }

    }

    public void ResetTimer() 
    {
        timeForTimer = 30;
        
    }

    public void SwitchTurns()
    {   
        if (worms[0].GetComponent<PlayerController>().enabled == false)
        {
            worms[0].GetComponent<PlayerController>().enabled = true;
            worms[1].GetComponent<PlayerController>().enabled = false;
            activeWorm = Worm2;
        }
        else
        {
            worms[1].GetComponent<PlayerController>().enabled = true;
            worms[0].GetComponent<PlayerController>().enabled = false;
            activeWorm = Worm1;
        }
    }

    public void NextTurn( float WaitTime)
    {
        if (WaitTime >= 1)
        {
            timeForTimer = WaitTime;
        }
    }


    private IEnumerator GameOver()
    {
        
        yield return new WaitForSeconds(3);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        

    }
}
