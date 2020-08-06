using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    public gameMaster gm;

    public Transform playerTransform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerRespawn();
        }
    }
    void playerRespawn()
    {
        playerTransform.position = gm.lastCheckpointPos;

    }
}
