using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Spawn Related")]
    public GameObject healthPack;
    bool _hasSpawned = false;
    public Transform[] spawnPoints;

    public GameObject[] healthKits;




    void Update()
    {

        healthKits = GameObject.FindGameObjectsWithTag("HealthKit");

        if (_hasSpawned == false && healthKits.Length == 0)
        {
            SpawnMedkit();
        }
        

    }

    void SpawnMedkit()
    {
        StartCoroutine("SpawnTimer");
    }

    private IEnumerator SpawnTimer()
    {
        
        Instantiate(healthPack, spawnPoints[Random.Range(0, spawnPoints.Length)].position, healthPack.transform.rotation); 
        _hasSpawned = true;

        yield return new WaitForSeconds(1);
        _hasSpawned = false;
    }

}
