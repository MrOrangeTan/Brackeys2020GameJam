using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float runSpeed = 20f;
    public CharacterController2D controller;
    float horizontalMove = 0f;
    bool jump = false;

    public GameObject Rewind;


    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            GetComponent<Animator>().SetBool("walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walk", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKey(KeyCode.R))
        {
            Rewind.SetActive(true);
        }
        else
        {
            Rewind.SetActive(false);
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
