using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyThrow : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject holyPrefab;
    public Transform throwPoint;
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
                    GameObject throwHoly = Instantiate(holyPrefab, throwPoint.position, Quaternion.identity);
                    throwHoly.GetComponent<Rigidbody>().AddForce(transform.forward * 350); 
                    HasShoot = true; 
                    gameManager.SendMessage("NextTurn", 6);
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
