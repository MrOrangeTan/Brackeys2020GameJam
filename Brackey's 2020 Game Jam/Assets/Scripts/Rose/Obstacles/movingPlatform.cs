using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] private float platformSpeed;
    bool moveRight;
    //distance
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;

    private void Update()
    {
        if (transform.position.x < minDistance)
        {
            moveRight = true;
        }
        else if (transform.position.x > maxDistance)
        {
            moveRight = false;
        }

        if (moveRight)
        {
            transform.Translate(new Vector2(1, 0) * platformSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector2(-1, 0) * platformSpeed * Time.deltaTime);
        }
    }
}
