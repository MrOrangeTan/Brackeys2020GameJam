using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Killed : MonoBehaviour
{
    [SerializeField] Transform LevelStart;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("Player"))
            col.transform.position = LevelStart.position;

    }
}