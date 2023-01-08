using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The target to follow
    public Transform target;

    // Offset of the camera from the target
    public Vector3 offset;

    // Smooth time for the camera movement
    public float smoothTime = 0.3f;

    // Velocity of the camera
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        // Follow the target with a smooth damping
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
    }
}