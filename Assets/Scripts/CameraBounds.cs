using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBounds : MonoBehaviour
{
    [Header("Camera Boundaries")]
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (cam == null || !cam.orthographic)
            return;

        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        Vector3 position = transform.position;

        // Calculate the camera's allowed movement range.
        float minX = minBounds.x + halfWidth;
        float maxX = maxBounds.x - halfWidth;
        float minY = minBounds.y + halfHeight;
        float maxY = maxBounds.y - halfHeight;

        // Handle maps smaller than the camera's viewing area.
        if (minX > maxX)
            position.x = (minBounds.x + maxBounds.x) / 2f;
        else
            position.x = Mathf.Clamp(position.x, minX, maxX);

        if (minY > maxY)
            position.y = (minBounds.y + maxBounds.y) / 2f;
        else
            position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}