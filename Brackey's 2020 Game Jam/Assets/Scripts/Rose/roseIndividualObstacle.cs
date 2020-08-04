using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roseIndividualObstacle : MonoBehaviour
{
    //duration before they fall
    [SerializeField] private float maxTimeBeforeBreak;
    private float currentTimeBeforeBreak;

    //how long will it take for the blocks to respawn
    [SerializeField] private float maxRespawnTime;
    private float currentRespawnTime;

    private void Awake()
    {
        currentTimeBeforeBreak = maxTimeBeforeBreak;
        currentRespawnTime = maxRespawnTime;
    }

}
