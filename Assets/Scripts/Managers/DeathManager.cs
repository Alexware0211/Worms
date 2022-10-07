using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public GameObject[] worms;
    public GameObject gm;
    

    void Update()
    {
        if (worms[1].activeInHierarchy == false)
        { 
            gm.SendMessage("GameOverText", 2);
        }
        else if (worms[0].activeInHierarchy == false)
        {
            gm.SendMessage("GameOverText", 1);
        }
    }
}
