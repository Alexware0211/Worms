using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject rocket;
    public Transform rocketSpawn;
    public GameObject gameManager;
    public AudioSource _shootVoice;

    private TurnManager turnScript;
    bool _hasShot = false;

    public void Update()
    {
        if (gameObject == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!_hasShot)
                {
                    _shootVoice.Play();
                    GameObject spawnRocket = Instantiate(rocket, rocketSpawn.position, Quaternion.identity);
                    spawnRocket.GetComponent<Rigidbody>().AddForce(transform.forward * 700); 
                    _hasShot = true; 
                    gameManager.SendMessage("NextTurn", 3);
                    _hasShot = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }
    private IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(3);
        _hasShot = false;
    }

}
