using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roseSpike : MonoBehaviour
{
    [SerializeField] private float damageDone;

    [SerializeField] private playerClass classForPlayer;

    private void Awake()
    {
        classForPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<playerClass>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            classForPlayer.health -= damageDone;
        }
    }
}
