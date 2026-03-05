using UnityEngine;
using TMPro;

/// <summary>
/// WinScreenUI: Shown when the player wins.
/// Attach to Canvas in WinScene.
/// 
/// Scene setup:
/// - Canvas
///   - WinText (TextMeshProUGUI) → "You launched into the future!"
///   - FinalScoreText (TextMeshProUGUI) → shows final score
///   - SloganText (TextMeshProUGUI) → "We launch you into the future!"
///   - LogoImage (Image)
///   - RestartButton → calls OnRestartClicked()
///   - MainMenuButton → calls OnMainMenuClicked()
/// </summary>
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
