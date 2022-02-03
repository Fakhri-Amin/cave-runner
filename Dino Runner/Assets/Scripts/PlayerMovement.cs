using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpVelocity;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip dieSFX;

    private Rigidbody2D rb;
    private bool isGrounded;
    private GameManager gameManager;
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        animator.SetBool("isGrounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.PlayOneShot(dieSFX);
        animator.SetBool("isDead", true);
        gameManager.GameOver();
        FindObjectOfType<DistanceDisplay>().CheckHighScore();
    }

    private void Jump()
    {
        // if (Input.GetButtonDown("Jump"))
        // {
        //     if (isGrounded)
        //     {
        //         audioSource.PlayOneShot(jumpSFX);
        //         rb.velocity = Vector2.up * jumpVelocity;
        //         isGrounded = false;
        //     }
        // }
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (isGrounded)
            {
                audioSource.PlayOneShot(jumpSFX);
                rb.velocity = Vector2.up * jumpVelocity;
                isGrounded = false;
            }
        }
    }
}
