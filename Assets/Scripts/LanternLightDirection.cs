using UnityEngine;

public class LanternLightDirection : MonoBehaviour
{
    // Update runs once every frame while the game is playing.
    void Update()
    {
        // Check if the player presses W.
        // Rotate the lantern light upward.
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        // Check if the player presses S.
        // Rotate the lantern light downward.
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }

        // Check if the player presses A.
        // Rotate the lantern light to the left.
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }

        // Check if the player presses D.
        // Rotate the lantern light to the right.
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }
}
