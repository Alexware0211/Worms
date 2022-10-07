using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{   
    [Header("UI Elements")]
    public Image team1Bar;
    public Image team2Bar;

    [Header("GameObjects")]
    public GameObject[] worms;

    [Header("Animator")]
    public Animator anim;


    public void Update()
    {
        int Worm1HP = worms[0].GetComponent<Health>().healthLeft;
        int Worm2HP = worms[1].GetComponent<Health>().healthLeft;
        float _worm1HP = (float)Worm1HP;
        float _worm2HP = (float)Worm2HP;
        team1Bar.fillAmount = (_worm1HP / 100);
        team2Bar.fillAmount = (_worm2HP / 100);
        
        if (Worm2HP > Worm1HP)
        {
            anim.SetTrigger("switchBar");
        }
        else
        {
            anim.SetTrigger("switchBack");
        }

    } 
    
}
