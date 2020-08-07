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

    //adjusting the scale
    public float characterScaleAdjustment;
    //hero class
    [SerializeField] private playerClass classForPlayer;
    [SerializeField] private float damageIfNotMoving;

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

        playerMovement();
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

    void playerMovement()
    {

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * classForPlayer.movementSpeed, rb.velocity.y) * Time.deltaTime;

        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, GroundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
