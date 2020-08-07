using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask GroundLayer;

    //adjusting the scale
    public float characterScaleAdjustment;
    private playerClass classForPlayer;

    public GameObject StaticEffect;
    public Vector3 StartPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        classForPlayer = GetComponent<playerClass>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(ShowStatic());
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator ShowStatic()
    {
        StaticEffect.SetActive(true);
        yield return new WaitForSeconds(1);
        transform.position = StartPosition;
        StaticEffect.SetActive(false);
    }

    private void Update()
    {
        flipCharacter();
     

        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, GroundLayer);

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * classForPlayer.movementSpeed * Time.deltaTime * 15, rb.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump"))
            rb.AddForce(Vector2.up * jumpSpeed * 100, ForceMode2D.Force);
    }
    private void flipCharacter()
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
}
