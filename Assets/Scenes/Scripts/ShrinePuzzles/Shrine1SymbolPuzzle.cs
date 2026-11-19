using UnityEngine;

public class Shrine1SymbolPuzzle : MonoBehaviour
{
    [SerializeField] private SymbolStoneInteraction[] stones;
    [SerializeField] private GameObject shrineOrb;
    private readonly int[] targetPattern = { 1, 2, 0 };

    private bool puzzleCompleted = false;

    private void Update()
    {
        if(puzzleCompleted || stones == null || stones.Length != targetPattern.Length)
        {
            return;
        }

        for(int i = 0; i < stones.Length; i++)
        {
            if (stones[i] == null || stones[i].CurrentSymbol != targetPattern[i])
            {
                return;
            }
        }
        puzzleCompleted = true;

        if(shrineOrb != null)
        {
            shrineOrb.SetActive(true);
        }

        Debug.Log("Shrine 1puzzle completed! Orb Unlocked.");
    }
}
