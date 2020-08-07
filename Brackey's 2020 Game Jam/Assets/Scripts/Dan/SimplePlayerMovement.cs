using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask GroundLayer;

    //adjusting the scle
    public float characterScaleAdjustment;
    //hero class
    [SerializeField] private playerClass classForPlayer;
    [SerializeField] private float damageIfNotMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        classForPlayer = GetComponent<playerClass>();
    }

    private void Update()
    {
        flipCharacter();

        playerMovement();
    }
    void flipCharacter()
    {
        //flip characer 
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = characterScaleAdjustment * -1;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = characterScaleAdjustment;
        }
        transform.localScale = characterScale;
    }
    void playerMovement()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, GroundLayer);

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * classForPlayer.movementSpeed, rb.velocity.y) * Time.deltaTime;

        if (isGrounded && Input.GetButtonDown("Jump"))
            rb.velocity = Vector2.up * jumpForce;
    }
}
