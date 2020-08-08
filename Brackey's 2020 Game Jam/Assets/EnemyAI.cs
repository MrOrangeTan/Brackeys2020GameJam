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
        if (waypoints.Length == 2)
        {
            if (speed < 1)
                speed += 0.05f;
            transform.position = Vector3.Lerp(waypoints[0].position, waypoints[1].position, speed - rewindFactor);
            if (PlayerMovement.rewind && rewindFactor < 1)
                rewindFactor += 0.01f;
            else if (rewindFactor > 0)
                rewindFactor -= 0.01f;
        }

        if (waypoints.Length == 3)
        {
            if (speed < 2)
                speed += 0.05f;

            if (speed - rewindFactor > 0 && speed - rewindFactor <= 1)
            {
                transform.position = Vector3.Lerp(waypoints[0].position, waypoints[1].position, speed - rewindFactor);
                transform.eulerAngles = new Vector3(0, 0, -90);
            }
            else if (speed - rewindFactor > 1)
            {
                transform.position = Vector3.Lerp(waypoints[1].position, waypoints[2].position, speed - rewindFactor - 1);
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (PlayerMovement.rewind && rewindFactor < 2)
                rewindFactor += 0.01f;
            else if (rewindFactor > 0)
                rewindFactor -= 0.01f;
        }
    }
}
