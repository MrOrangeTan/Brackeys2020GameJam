using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionWithMovingPlatforms : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mobilePlatforms")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mobilePlatforms")
        {
            transform.parent = null;
        }
    }
}
