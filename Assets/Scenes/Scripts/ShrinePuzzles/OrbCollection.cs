using UnityEngine;

public class OrbCollection : MonoBehaviour
{
    private bool playerInRange = false;

    private bool collected = false;

    private void Update()
    {
        if(playerInRange && !collected && Input.GetKeyDown(KeyCode.E))
        {
            CollectOrb();
        }
    }

    private void CollectOrb()
    {
        if(collected)
        {
            return;
        }

        if(OrbCollectionManager.Instance == null)
        {
            Debug.LogError("OrbCollectionManager is missing!");
            return;
        }

        if(!OrbCollectionManager.Instance.TryCollectOrb())
        {
            return;
        }

        collected = true;
        Debug.Log("Flowing orb collected!");
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
