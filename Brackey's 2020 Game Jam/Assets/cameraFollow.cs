using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.2f;
    private Vector3 velocity= Vector3.zero;
    [SerializeField] private Vector3 changeTargetPosition;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(changeTargetPosition);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
