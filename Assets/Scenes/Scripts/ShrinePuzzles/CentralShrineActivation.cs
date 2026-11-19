using UnityEngine;
using UnityEngine.Rendering;

public class CentralShrineActivation : MonoBehaviour
{
    [Header("Activation Settings")]
    [SerializeField, Range(1, 5)]
    private int requiredOrbs = 5;

    [Header("visuals")]
    [SerializeField] private SpriteRenderer shrineRenderer;

    private bool playerInRange = false;
    private bool activated = false;

    public bool IsActivated => activated;

    private void Start()
    {
        if(shrineRenderer == null)
        {
            shrineRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if(playerInRange && !activated && Input.GetKeyDown(KeyCode.E))
        {
            TryActivate();
        }
    }

    private void TryActivate()
    {
        OrbCollectionManager manager = OrbCollectionManager.Instance;

        if (manager == null)
        {
            Debug.LogError("OrbCollectionManager missing!");
            return;
        }

        if (manager.CollectedOrbs < requiredOrbs)
        {
            Debug.Log("CentralShrine needs " + requiredOrbs + " flowing orb(s).");
            return;
        }

        activated = true;

        if (shrineRenderer != null)
        {
            shrineRenderer.color = Color.cyan;
        }

        Debug.Log("Central Shrine activated!");

        ForestExit exit = FindFirstObjectByType<ForestExit>();

        if(exit != null)
        {
            exit.UnlockExit();
        }
        else
        {
            Debug.LogWarning("Forest Exit not found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
