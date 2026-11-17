using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The player the camera will follow.
    public Transform target;

    // Controls how smoothly the camera follows.
    public float smoothSpeed = 5f;

    // Stores the camera's starting distance from the player.
    private Vector3 offset;

    void Start()
    {
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        // Stop if no player has been assigned.
        if (target == null)
        {
            return;
        }

        // Calculate the camera's desired position.
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera toward the player.
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
            );
    }
}