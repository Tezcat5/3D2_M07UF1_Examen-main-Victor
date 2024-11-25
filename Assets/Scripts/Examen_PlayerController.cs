using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examen_PlayerController : MonoBehaviour
{
    private Rigidbody2D characterRigidbody;
    private float horizontalInput;

    [SerializeField] private float characterSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;

    private Animator characterAnimator;

    void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > 0.1f) 
        {
            characterAnimator.SetBool("IsRunning", true);
        }
        else
        {
            characterAnimator.SetBool("IsRunning", false);
        }

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); 
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); 
        }

        if (Input.GetButtonDown("Jump") && Examen_GroundSensor.isGrounded)
        {
            Jump();
        }

        characterAnimator.SetBool("IsJumping", !Examen_GroundSensor.isGrounded);
    }

    void FixedUpdate()
    {
        characterRigidbody.velocity = new Vector2(horizontalInput * characterSpeed, characterRigidbody.velocity.y);
    }

    void Jump()
    {
        characterRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
