using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVoicelines : MonoBehaviour
{
    public AudioSource[] voiceLines;

    float _timer;


    void Start()
    {
        _timer = Random.Range(5, 20);
    }

    public void Update()
    {
        if (_timer <= 0)
        {
            voiceLines[Random.Range (0, voiceLines.Length)].Play();
            _timer = Random.Range(5, 35);
        }

        _timer -= Time.deltaTime;


    }
}
