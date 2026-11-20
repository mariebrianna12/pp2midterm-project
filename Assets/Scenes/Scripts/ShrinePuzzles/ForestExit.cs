using UnityEngine;

public class ForestExit : MonoBehaviour
{
    [SerializeField] private SpriteRenderer exitRenderer;

    private bool unlocked = false;
    private bool gameCompleted = false;

    private void Start()
    {
        if(exitRenderer == null)
        {
            exitRenderer = GetComponent<SpriteRenderer>();
        }

        UpdateAppearance();
    }

    public void UnlockExit()
    {
        if (unlocked) return;

        unlocked = true;
        UpdateAppearance();

        Debug.Log("Forest Exit unlocked!");
    }

    private void UpdateAppearance()
    {
        if(exitRenderer != null)
        {
            exitRenderer.color = unlocked ? Color.green : Color.red;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if(!unlocked)
        {
            Debug.Log("Forest Exit is locked.");
            return;
        }

        if (gameCompleted) return;

        gameCompleted = true;
        Debug.Log("YOU ESCAPED THE FOREST!");
    }
}
