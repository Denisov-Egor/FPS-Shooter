using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public bool crouching = false;
    public bool lerpCrouch = false;
    public bool sprinting = false;
    public float speed = 1.5f;
    public float gravity = -9.8f;
    public float junpHeight = 3f;
    /*public float crouchTimer = 1f;
    private float crouchingTimer = 0f;*/

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

      /*if (lerpCrouch)
        {
            crouchingTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }*/
    }

    public void ProcessMove(Vector2 input){
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(junpHeight * -3.0f * gravity);
        }
    }

    /*public void Crounch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }*/

    public void Sprint()
    {
        sprinting = !sprinting;

        if (sprinting)
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }
    }
}