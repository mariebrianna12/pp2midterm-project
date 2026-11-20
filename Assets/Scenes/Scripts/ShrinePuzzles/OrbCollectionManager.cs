using UnityEngine;
using TMPro;

public class OrbCollectionManager : MonoBehaviour
{
   public static OrbCollectionManager Instance { get; private set; }

    public const int MaxOrbs = 5;
    [SerializeField] private TMP_Text orbCounterText;
    public int CollectedOrbs { get; private set; } = 0;
    public bool HasAllOrbs => CollectedOrbs >= MaxOrbs;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Debug.LogError("Duplicate OrbCollectionManager detected.");
            enabled = false;
            return;
        }
        Instance = this;
        UpdateCounterUI();
    }

    public bool TryCollectOrb()
    {
        if(CollectedOrbs >= MaxOrbs)
        {
            return false;
        }

        CollectedOrbs++;
        UpdateCounterUI();

        Debug.Log("Flowing orbs collected: " + CollectedOrbs + "/" + MaxOrbs);

        return true;
    }

    private void UpdateCounterUI()
    {
        if(orbCounterText != null)
        {
            orbCounterText.text = "Orbs: " + CollectedOrbs + "/" + MaxOrbs;
        }
    }
}
