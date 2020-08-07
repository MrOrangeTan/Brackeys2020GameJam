using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.2f;

    [SerializeField] private Vector3 changeCameraPerspective = Vector3.zero;
    Vector3 cameraVelocity = Vector3.zero;

    private void FixedUpdate()
    {
        //the camera's position
        Vector3 targetPosition = target.TransformPoint(changeCameraPerspective);

        //move the camera with the player
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);
    }
}
