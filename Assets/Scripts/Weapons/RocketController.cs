using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public ParticleSystem explostionEffect;
    public float rotationSpeed = 0.5f;
    bool _hasCollided = false;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        
        Vector3 dir = GetComponent<Rigidbody>().velocity.normalized;
        if (_hasCollided == false)
        {
            transform.rotation = Quaternion.LookRotation(dir);
        }
        if (dir != Vector3.zero && _hasCollided == false)
        {
            transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(dir),
            Time.deltaTime * rotationSpeed
            );
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {   
        _hasCollided = true;
        explostionEffect.Play();
        Debug.Log(collision.collider.name);
        AreaDamage(gameObject.transform.position, 10, 10);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Destroy(gameObject,1);
    }



    /// <summary>
    /// The intended function is to apply damage over distance on the grenade, however it isn't working at intended..
    /// Instead I'll just have to say, do 40 damage no matter the distance from the nade, as long as you are inside..
    /// </summary>
    void AreaDamage(Vector3 location, float radius, float damage)
    {
        Collider[] objectInRange = Physics.OverlapSphere(location, radius);
        foreach(Collider col in objectInRange)
        {
            Health worm = col.GetComponent<Health>();
            if (worm != null)
            {
                
                float proximity = (location - worm.transform.position).magnitude;
                float effect = 1 - (proximity / radius);
                
                float _damage = (damage * effect);

                int DamageTaken = (int)Mathf.Round(_damage);
                
                //worm.ApplyDamage(damage * effect);
                worm.ApplyDamage(DamageTaken);
            }
        }
    }
}
