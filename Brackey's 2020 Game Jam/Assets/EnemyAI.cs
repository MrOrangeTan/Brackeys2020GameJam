using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints;
    private float speed;
    private float rewindFactor;

    private void Update()
    {
        if (speed < 1)
            speed += 0.05f;
        if (waypoints.Length == 2)
            transform.position = Vector3.Lerp(waypoints[0].position, waypoints[1].position, speed - rewindFactor);

        if (PlayerMovement.rewind && rewindFactor < 1)
            rewindFactor += 0.01f;
        else if (rewindFactor > 0)
            rewindFactor -= 0.01f;
    }
}
