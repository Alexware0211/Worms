using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    Vector3 velocity;
    float gravity = -9.81f;
    CharacterController controller;



    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {

        if (gameObject.GetComponent<PlayerController>().enabled == false)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        
        
    }
}
