using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public Animator camAnim;

    public void shakeCam()
    {
        camAnim.SetTrigger("shake");
    }
}
