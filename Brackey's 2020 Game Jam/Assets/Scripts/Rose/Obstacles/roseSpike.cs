using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roseSpike : MonoBehaviour
{
    [SerializeField] private float damageDone;

    [SerializeField] private playerClass classForPlayer;
    [HideInInspector] public bool spikeHit;

    //time since the game loaded
    int timeSinceGameStarted = 0;

    //random timing for the spike to come out
    [SerializeField] private int randomStab;
    //currentNumber
    int currentRandomStab;
    //To check if the spike is out
    bool isSpikeOut = false;

    //setting the variable for the script
    public healthInteractions healthUpdate;

    //reference to the animator
    [SerializeField] private Animator animator;

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

    private void Update()
    {
        timeSinceGameStarted += 1;
        
        //To make the boolean true, I need to make the animation happen,I need to play the animation, I can only play if the time hits the random timing
        if (timeSinceGameStarted == currentRandomStab)
        {
            Debug.Log(isSpikeOut);
            timeSinceGameStarted = 0;
            animator.SetTrigger("spikeUp");
            isSpikeOut = true;
        }
        else
        {
            isSpikeOut = false;
        }
        //random timing that happens when the spike goes down
        if (!isSpikeOut)
        {
            currentRandomStab = Random.Range(0, randomStab);
            isSpikeOut = false;
        }
    }
}
