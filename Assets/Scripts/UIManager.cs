using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// UIManager: Controls all HUD elements during gameplay.
/// Attach to a Canvas GameObject in the GameScene.
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("HUD")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI difficultyText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScore(0);
        UpdateLives(3);
    }

    void Update()
    {
        // Keep score and difficulty display up to date
        if (GameManager.Instance != null)
        {
            UpdateScore(GameManager.Instance.score);

            if (difficultyText != null)
            {
                int level = Mathf.FloorToInt(GameManager.Instance.difficultyMultiplier);
                difficultyText.text = "Level: " + level;
            }
        }
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int lives)
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }
}
