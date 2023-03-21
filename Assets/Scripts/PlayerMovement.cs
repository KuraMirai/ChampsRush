using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 500.0f;
    public float swimSpeed = 5.0f;
    public float climbSpeed = 5.0f;
    public float flySpeed = 10.0f;

    private bool isGrounded = false;
    private bool isSwimming = false;
    private bool isClimbing = false;
    private bool isFlying = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (isGrounded && !isSwimming && !isClimbing && !isFlying)
        {
            // Ground movement
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * moveSpeed);

            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
        else if (isSwimming)
        {
            // Swimming movement
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * swimSpeed);
        }
        else if (isClimbing)
        {
            // Climbing movement
            float moveVertical2 = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
            rb.AddForce(movement * climbSpeed);
        }
        else if (isFlying)
        {
            // Flying movement
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
            rb.AddForce(movement * flySpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGrounded = true;
        }

        else if (other.tag == "Water")
        {
            isSwimming = true;
            isClimbing = false;
            isFlying = false;
        }
        else if (other.tag == "Mountain")
        {
            isClimbing = true;
            isSwimming = false;
            isFlying = false;
        }
        else if (other.tag == "Sky")
        {
            isFlying = true;
            isSwimming = false;
            isClimbing = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            isSwimming = false;
        }
        else if (other.tag == "Mountain")
        {
            isClimbing = false;
        }
        else if (other.tag == "Sky")
        {
            isFlying = false;
        }
        else if (other.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
    }
}