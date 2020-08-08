using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static bool rewind;
    public float rewindDuration = 1;
    public bool canRewind = true;
    public Image Fill;

    public float runSpeed = 20f;
    public CharacterController2D controller;
    float horizontalMove = 0f;
    bool jump = false;

    public GameObject Rewind;

    private IEnumerator Cooldown()
    {
        canRewind = false;
        yield return new WaitForSeconds(0.5f);
        canRewind = true;
    }


    void Update()
    {
        if (rewindDuration < 1)
            rewindDuration += 0.02f;

        if (rewindDuration < 0.01f && canRewind)
            StartCoroutine(Cooldown());

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

        if (Input.GetKey(KeyCode.R) && rewindDuration > 0 && canRewind)
        {
            Rewind.SetActive(true);
            rewind = true;
            rewindDuration -= 0.025f;
        }
        else
        {
            Rewind.SetActive(false);
            rewind = false;
        }

        Fill.fillAmount = rewindDuration / 1;

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
