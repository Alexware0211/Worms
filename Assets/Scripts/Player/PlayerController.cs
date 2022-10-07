using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Animations")]
    private float _moveSpeed;
    

    [Header("Movement")]
    public float speed = 5;
    private float _turnSmoothTime = 0.1f;
    public Transform cam;
    public float jumpHeight = 6;
    
    //Private Stuff
    Animator anim;
    CharacterController controller;
    float turnSmoothVelocity;
    Vector3 velocity;
    float gravity = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 newDir = cam.right * horizontal + cam.forward * vertical;
        newDir.Normalize();

        if (newDir.magnitude >= 0.1f) // Turn the character making it face the direction it's moving. The turn is more smooth rather than quick and chopy.Also make the camera controll rotation and movement
        {
            float targetAngle = Mathf.Atan2(newDir.x, newDir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) // Using the built in isGrounded to check if the controller(Player) is touching the ground
        {
            velocity.y = jumpHeight;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // As the built in character controller lack built in gravity I had to apply gravity.
        }

        controller.Move(velocity * Time.deltaTime);

        anim.SetFloat("WalkSpeed", newDir.magnitude * 1000000); // Magnitude was below 1 so had to ensure it went above 2.

    }

}
