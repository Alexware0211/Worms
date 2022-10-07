using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{   

    [Header("UI")]
    public TextMeshPro healthText;

    [Header("Values")]
    public int healthLeft = 100;

    [Header("GameObjects")]
    public GameObject tombstone;
    public Transform tomestoneSpawn;

    [Header("VoiceLines")]
    public AudioSource[] voiceLines;
    
    bool _isDead = false;
    bool _takeDamage = false;
    
    void Update()
    {
        healthText.text = healthLeft.ToString();

        if (healthLeft <= 0 && _isDead == false)
        {
            Instantiate(tombstone, tomestoneSpawn.position, Quaternion.identity);
            _isDead = true;
            gameObject.SetActive(false);
        }

        if (_takeDamage == true)
        {
            voiceLines[Random.Range (0, voiceLines.Length)].Play();
            _takeDamage = false;
        }
    }

    public void ApplyDamage(int amount)
    {
        healthLeft -= amount;
        _takeDamage = true;
    }
 
}
