using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the Safe Zone
        PlayerMovement player =
            other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            // Mark the player as safe
            player.isSafe = true;

            // Testing message
            Debug.Log("Player entered Safe Zone");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player left the Safe Zone
        PlayerMovement player =
            other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            // Player is no longer safe
            player.isSafe = false;

            // Testing message
            Debug.Log("Player exited Safe Zone");
        }
    }
}
