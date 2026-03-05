using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    
    public void OnPlayClicked()
    {
        GameManager.Instance.StartGame();
    }

    
    public void OnQuitClicked()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
