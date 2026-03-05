using UnityEngine;
using TMPro;

/// <summary>
/// LoseScreenUI: Shown when the player loses all lives.
/// Attach to Canvas in LoseScene.
/// 
/// Scene setup:
/// - Canvas
///   - LoseText (TextMeshProUGUI) → "Game Over!"
///   - FinalScoreText (TextMeshProUGUI) → shows final score
///   - SloganText (TextMeshProUGUI) → "We launch you into the future!"
///   - LogoImage (Image)
///   - RestartButton → calls OnRestartClicked()
///   - MainMenuButton → calls OnMainMenuClicked()
/// </summary>
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
