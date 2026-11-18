using UnityEngine;

public class Shrine1SymbolPuzzle : MonoBehaviour
{
    // Correct order: B, A, C
    private readonly int[] correctSequence = { 1, 0, 2 };

    private int currentStep = 0;
    private bool puzzleCompleted = false;

    public void SelectSymbol(int symbolIndex)
    {
        if (puzzleCompleted)
        {
            return;
        }

        if (symbolIndex == correctSequence[currentStep])
        {
            currentStep++;
            Debug.Log("Correct symbol!");

            if (currentStep == correctSequence.Length)
            {
                puzzleCompleted = true;
                Debug.Log("Shrine 1 puzzle completed! Orb unlocked.");
            }
        }
        else
        {
            currentStep = 0;
            Debug.Log("Incorrect symbol! Sequence reset.");
        }
    }
}
