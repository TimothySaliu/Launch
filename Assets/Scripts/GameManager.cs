using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// GameManager: Central controller for all game states.
/// Attach to a persistent "GameManager" GameObject in every scene.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton so any script can access it

    [Header("Game State")]
    public bool isGameActive = false;
    public int score = 0;
    public float gameTime = 0f;

    [Header("Difficulty")]
    public float difficultyMultiplier = 1f;
    public float difficultyIncreaseRate = 0.1f; // increases every 10 seconds
    private float difficultyTimer = 0f;

    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    void Awake()
    {
        // Singleton pattern: only one GameManager exists at a time
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!isGameActive) return;

        // Track game time
        gameTime += Time.deltaTime;

        // Increase difficulty every 10 seconds
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer >= 10f)
        {
            difficultyTimer = 0f;
            difficultyMultiplier += difficultyIncreaseRate;
            Debug.Log("Difficulty increased to: " + difficultyMultiplier);
        }

        // Update UI
        if (timerText != null)
            timerText.text = "Time: " + Mathf.FloorToInt(gameTime) + "s";
    }

    public void StartGame()
    {
        score = 0;
        gameTime = 0f;
        difficultyMultiplier = 1f;
        difficultyTimer = 0f;
        isGameActive = true;
        SceneManager.LoadScene("GameScene");
    }

    public void AddScore(int points)
    {
        score += points;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void WinGame()
    {
        isGameActive = false;
        SceneManager.LoadScene("WinScene");
    }

    public void LoseGame()
    {
        isGameActive = false;
        SceneManager.LoadScene("LoseScene");
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void GoToMainMenu()
    {
        isGameActive = false;
        SceneManager.LoadScene("MainMenu");
    }
}
