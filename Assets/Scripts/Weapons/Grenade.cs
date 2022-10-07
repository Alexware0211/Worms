using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [Header("Sound/Visual Effects")]
    public ParticleSystem explositonEffect;

    Rigidbody rb;


    public void Start()
    {
        StartCoroutine("WaitForSound");
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(3);
        explositonEffect.Play();
        AreaDamage(gameObject.transform.position, 14, 20);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Destroy(gameObject, 1);
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
