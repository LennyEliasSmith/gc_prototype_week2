using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float aerialSpeedModifierX = 0.8f;
    public float aerialSpeedModifierZ = 0.2f;
    public float aerialSpeedMax = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private Vector3 moveVelocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            moveVelocity = transform.right * x + transform.forward * z;
        }

        if (isGrounded)
        {
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }
        else
        {
            // controller.Move(moveVelocity * speed * Time.deltaTime);

            Vector3 aerialMovement = transform.right * x * aerialSpeedModifierX + transform.forward * z * aerialSpeedModifierZ;
            if((moveVelocity + aerialMovement).magnitude < 2)
            {
                moveVelocity += aerialMovement;
            }

            controller.Move(moveVelocity * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
