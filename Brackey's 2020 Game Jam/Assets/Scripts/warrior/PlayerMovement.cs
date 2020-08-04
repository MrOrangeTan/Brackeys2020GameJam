using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D Controller;
    float HorizontalMove = 0f;
    public float Speed = 10f;
    bool jump = false;


    void Update ()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * Speed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate ()
    {
        Controller.Move(HorizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
