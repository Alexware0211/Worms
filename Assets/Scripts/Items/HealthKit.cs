using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {   
        other.GetComponent<Health>().healthLeft+=10;

        Destroy(gameObject);

    }
}
