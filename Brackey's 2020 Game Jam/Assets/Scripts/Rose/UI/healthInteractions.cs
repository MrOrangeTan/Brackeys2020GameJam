using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthInteractions : MonoBehaviour
{
    public Text healthText;
    public roseSpike spike;
    [SerializeField] private playerClass classForPlayer;

    private void Awake()
    {   
        healthText.text = "Health: " + classForPlayer.health;
    }

    private void Update()
    {
        healthText.text = "Health: " + classForPlayer.currentHealth.ToString("f0");
        //if (spike.spikeHit)
        //{
        //    interactionWithHealth();
        //}
    }

    void interactionWithHealth()
    {
        healthText.text = "Health: " + classForPlayer.currentHealth;
    }
}
