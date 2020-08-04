using System.Collections;
using UnityEngine;

public class roseIndividualObstacle : MonoBehaviour
{
    //duration before the block fall
    [SerializeField] private float TimeBeforeBreak;

    //how long will it take for the blocks to respawn
    [SerializeField] private float timeToRespawn;
    private Transform thistransform;

    private void Awake()
    {
        thistransform = this.transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(countdownBeforeBreak());
        }
    }

    IEnumerator countdownBeforeBreak()
    {
        //waiting for the time
        yield return new WaitForSeconds(TimeBeforeBreak);
        //then it will not be active
        //Destroy(gameObject);
    }


    IEnumerator respawnTime()
    {
        yield return new WaitForSeconds(timeToRespawn);
        Instantiate(gameObject, thistransform.position, thistransform.rotation);
    }

}
