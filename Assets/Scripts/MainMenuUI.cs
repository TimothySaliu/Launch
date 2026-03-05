using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// MainMenuUI: Controls the main menu screen.
/// Attach to the Canvas in the MainMenu scene.
/// 
/// Scene setup:
/// - Canvas
///   - TitleText (TextMeshProUGUI) → "Best Education"
///   - SloganText (TextMeshProUGUI) → "We launch you into the future!"
///   - LogoImage (Image) → Drag in the Best Education logo sprite
///   - PlayButton (Button) → calls OnPlayClicked()
///   - QuitButton (Button) → calls OnQuitClicked()
/// </summary>
public class MainMenuUI : MonoBehaviour
{
    [Header("Brand Elements")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI sloganText;
    public Image logoImage;

    void Start()
    {
        // Ensure branding is visible
        if (titleText != null) titleText.text = "Best Education";
        if (sloganText != null) sloganText.text = "We launch you into the future!";
        // logoImage sprite should be assigned in Inspector
    }

    /// <summary>Assign this to the Play Button's OnClick event in Inspector.</summary>
    public void OnPlayClicked()
    {
        GameManager.Instance.StartGame();
    }

    /// <summary>Assign this to the Quit Button's OnClick event in Inspector.</summary>
    public void OnQuitClicked()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
