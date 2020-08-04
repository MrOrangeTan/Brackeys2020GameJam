using System.Collections;
using UnityEngine;

public class roseIndividualObstacle : MonoBehaviour
{
    //duration before the block fall
    [SerializeField] private float TimeBeforeBreak;
    private float currentTimeBeforeBreak;

    //how long will it take for the blocks to respawn
    [SerializeField] private float timeToRespawn;
    private float currentTimeToRespawn;

    //boolean
    private bool calledBreak = false;
    private bool calledRespawn = false;

    private void Awake()
    {
        currentTimeBeforeBreak = TimeBeforeBreak;
        currentTimeToRespawn = timeToRespawn;
    }

    private void Update()
    {
        //troubleshoot
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log(currentTimeBeforeBreak);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(currentTimeToRespawn);
        }
        
        //this works
        //if this is true,
        if (calledBreak)
        {
            //call tis method
            goingToBreak();
        }

        if (calledRespawn)
        {
            beforeRespawn();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            calledBreak = true;
        }
    }

    void goingToBreak()
    {
        currentTimeBeforeBreak -= Time.deltaTime;
        
        if (currentTimeBeforeBreak <= 0)
        {
            this.gameObject.SetActive(false);   
        }
    }

    private void OnDisable()
    {
        calledRespawn = true;
        calledBreak = false;
    }

    void beforeRespawn()
    {
        currentTimeToRespawn -= Time.deltaTime;

        if (currentTimeToRespawn <= 0)
        {
            this.gameObject.SetActive(true);
        }
    }
    private void OnEnable()
    {
        calledRespawn = false;
    }
}
