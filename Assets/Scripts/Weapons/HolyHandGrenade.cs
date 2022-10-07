using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyHandGrenade : MonoBehaviour
{
    [Header("Sound/Visual Effects")]
    public AudioSource holySound;
    public ParticleSystem explostionEffect;

    Rigidbody rb;


    public void Start()
    {
        StartCoroutine("WaitForSound");
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator WaitForSound()
    {
        yield return new WaitForSeconds(4);
        holySound.Play();

        yield return new WaitForSeconds(2);
        explostionEffect.Play();
        AreaDamage(gameObject.transform.position, 14, 20);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        //ImpactController.AddImpact(Vector3.up, 50000);
        Destroy(gameObject, 1);
    }


    /*
    void ExplosionForce()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }
    */
    // Was an attempt on making a explosion knockback however, realised I wasn't using rigidbodies so it's a bit redundant.
    


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
