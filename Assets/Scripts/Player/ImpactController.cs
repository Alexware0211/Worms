using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactController : MonoBehaviour
{

    // As I choose to use a character controller I will have to tell the character how to do a impact from a explosion etc rather than just telling the grenade
    // itself to add force and do some knockback.
    // As it currently is, this is not working. Will work on it later once I get all the main parts (G and VG) done.
    
    float _mass = 3;
    Vector3 impact = Vector3.zero;
    CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        //apply the force
        if (impact.magnitude > 0.2f) character.Move(impact * Time.deltaTime);

        impact = Vector3.Lerp(impact, Vector3.zero, 5*Time.deltaTime);
    }

    //Function to call in other scripts to tell them how much impact to apply 
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; 
        impact += dir.normalized * force / _mass;
    }


}
