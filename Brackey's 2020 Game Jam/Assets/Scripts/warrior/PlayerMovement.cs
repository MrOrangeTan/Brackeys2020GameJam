using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D Controller;
    float HorizontalMove = 0f;
    public float Speed = 10f;


    void Update ()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * Speed;
    }

    void FixedUpdate ()
    {
        Controller.Move(HorizontalMove * Time.fixedDeltaTime, false, false);
    }
}
