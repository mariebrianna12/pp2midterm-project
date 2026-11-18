using UnityEngine;

public class InteractionPromptController : MonoBehaviour
{
    // Reference to the interaction prompt UI.
    public GameObject interactionPrompt;


    // Tracks whether the player is within interaction range.
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        // Check whether the player presses E while nearby.
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player interacted with the object!");
            interactionPrompt.SetActive(false);
        }
    }
}