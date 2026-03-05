using UnityEngine;
using TMPro;


public class WinScreenUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI winMessageText;

    void Start()
    {
        // Show final score from GameManager
        if (finalScoreText != null && GameManager.Instance != null)
            finalScoreText.text = "Final Score: " + GameManager.Instance.score;

        if (winMessageText != null)
            winMessageText.text = "You launched into the future!";
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
