using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject grenadePrefab;
    public Transform throwPoints;
    public GameObject gameManager;

    public AudioSource[] throwVoice;

    bool HasShoot = false;

    public void Update()
    {
        if (gameObject == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!HasShoot)
                {
                    throwVoice[Random.Range(0, throwVoice.Length)].Play();
                    StartCoroutine("WaitForSound");
                    GameObject grenadeThrow = Instantiate(grenadePrefab, throwPoints.position, Quaternion.identity);
                    grenadeThrow.GetComponent<Rigidbody>().AddForce(transform.up * 450); 
                    HasShoot = true; 
                    gameManager.SendMessage("NextTurn", 4);
                    HasShoot = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }
    private IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(1);
    }
}
