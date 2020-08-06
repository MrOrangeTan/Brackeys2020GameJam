using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roseSpike : MonoBehaviour
{
    [SerializeField] private float damageDone;

    [SerializeField] private playerClass classForPlayer;
    [HideInInspector] public bool spikeHit;

    //setting the variable for the script
    public healthInteractions healthUpdate;

    private void Awake()
    {
        //getting the component
        healthUpdate = FindObjectOfType<healthInteractions>();
        spikeHit = false;
        classForPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<playerClass>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            classForPlayer.currentHealth -= damageDone;
            //if it hits the player, the component will be equilavent to this spike
            healthUpdate.spike = this;
            spikeHit = true;
        }
    }
}
