using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenController : MonoBehaviour
{
    // Reference to the Game Over panel.
    public GameObject gameOverPanel;

    // Hide the Game Over screen when the game starts.
    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Game Over Panel is not assigned!");
        }

        Time.timeScale = 1f;
    }

    // Display the Game Over screen when the player loses.
    public void ShowGameOverScreen()
    {
        if (gameOverPanel == null)
        {
            Debug.LogError("Game Over Panel is not assigned!");
            return;
        }

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        Debug.Log("Game Over Screen displayed!");
    }

    // Restart the current level.
    public void TryAgain()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Return to the Main Menu.
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MainMenu");
    }

    // TEMPORARY TEST: Press G to display the Game Over screen.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ShowGameOverScreen();
        }
    }
}