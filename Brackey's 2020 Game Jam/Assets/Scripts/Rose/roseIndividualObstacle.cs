using System.Collections;
using UnityEngine;

public class roseIndividualObstacle : MonoBehaviour
{
    //Time before the block the player is standing on breaks
    [SerializeField] private float timeBeforeBreak;
    [SerializeField]private float currentTimeBeforeBreak;

    //respawn time
    [SerializeField] private float respawnTime;
    [SerializeField]private float currentRespawnTime;

    //boolean to check if the block is touch
    bool isBlockTouch;

    //boolean to check if its time to respawn
    bool timeToRespawn;

    //this gameobject transform
    [SerializeField] private Transform respawnBlock;
    
    private void Awake()
    {
        isBlockTouch = false;
        timeToRespawn = false;
        respawnBlock = this.gameObject.transform;
    }
    private void Start()
    {
        currentTimeBeforeBreak = timeBeforeBreak;
        currentRespawnTime = respawnTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if this collides with the player
        if (collision.gameObject.tag == "Player")
        {
            //make is touch to true so it can be called under Update
            isBlockTouch = true;

        }
    }

    private void Update()
    {
        //if this is true
        if (isBlockTouch)
        {
            //time before the block breaks will minus 1 sec based on the time when last frame was drawn
            blockDestroying();
        }

        if (timeToRespawn)
        {
            blockRespawning();
        }
        
        else if (!isBlockTouch || !timeToRespawn)
        {
            return;
        }
    }

    void blockDestroying()
    {
        //if the block breaker timer reaches zero
        if (currentTimeBeforeBreak <= 0)
        {
            currentTimeBeforeBreak = timeBeforeBreak;
            timeToRespawn = true;
            //this gameobject will be destroyed
            Destroy(gameObject);
        }
        else
            currentTimeBeforeBreak -= Time.deltaTime;
    }



    void blockRespawning()
    {   
        if (currentRespawnTime <= 0)
        {
            timeToRespawn = false;
            Instantiate(respawnBlock, respawnBlock.transform.position, Quaternion.identity);
            currentRespawnTime = respawnTime;
        }
        else
            currentRespawnTime -= Time.deltaTime;
    }
}
