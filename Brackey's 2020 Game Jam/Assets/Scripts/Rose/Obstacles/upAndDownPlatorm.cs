using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upAndDownPlatorm : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;

    bool movingUp;

    private void Update()
    {
     if (transform.position.y > maxDistance)
        {
            movingUp = false;
        }
     if (transform.position.y < minDistance)
        {
            movingUp = true;
        }

     if (movingUp)
        {
            transform.Translate(new Vector2(0, movementSpeed)* Time.deltaTime);
        }
     else
        {
            transform.Translate(new Vector2(0, -movementSpeed) * Time.deltaTime);
        }
    }
}
