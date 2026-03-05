using UnityEngine;
using TMPro;


public class LoseScreenUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI loseMessageText;

    void Start()
    {
        if (finalScoreText != null && GameManager.Instance != null)
            finalScoreText.text = "Final Score: " + GameManager.Instance.score;

        if (loseMessageText != null)
            loseMessageText.text = "Game Over! Better luck next time.";
    }

    public void OnRestartClicked()
    {
        GameManager.Instance.RestartGame();
    }

    public void OnMainMenuClicked()
    {
        GameManager.Instance.GoToMainMenu();
    }
}
