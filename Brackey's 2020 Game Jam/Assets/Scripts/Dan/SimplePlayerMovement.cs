﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask GroundLayer;

    //hero class
    [SerializeField] private playerClass classForPlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        classForPlayer = GetComponent<playerClass>();
    }

    private void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, GroundLayer);

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * classForPlayer.movementSpeed, rb.velocity.y) * Time.deltaTime;

        if (isGrounded && Input.GetButton("Jump"))
            rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime * 100, ForceMode2D.Force);
    }
}
