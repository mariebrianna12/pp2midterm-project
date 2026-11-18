using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreenController : MonoBehaviour
{
    // Reference to the Victory Screen panel.
    public GameObject victoryPanel;

    // Hide the Victory Screen when the game starts.
    private void Start()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Victory Panel is not assigned!");
        }

        // Make sure gameplay is not paused at startup.
        Time.timeScale = 1f;
    }

    // TEMPORARY TEST: Press V to display the Victory Screen.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ShowVictoryScreen();
        }
    }

    // Show the Victory Screen when the player wins.
    public void ShowVictoryScreen()
    {
        if (victoryPanel == null)
        {
            Debug.LogError("Victory Panel is not assigned!");
            return;
        }

        victoryPanel.SetActive(true);

        // Pause gameplay after victory.
        Time.timeScale = 0f;

        Debug.Log("Victory Screen displayed!");
    }

    // Restart the current level.
    public void PlayAgain()
    {
        Time.timeScale = 1f;

        Debug.Log("Restarting the current level!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Return to the Main Menu.
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }
}