using UnityEngine;

/// <summary>
/// BackgroundScroller: Makes the background scroll downward to simulate flying through space.
/// Attach to background sprite(s). Use 2 identical backgrounds stacked vertically to loop seamlessly.
/// 
/// Setup:
/// 1. Create two Sprite GameObjects with your background image
/// 2. Stack them: BG1 at y=0, BG2 at y=10 (height of background)
/// 3. Attach this script to BOTH
/// </summary>
public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetY = -10f;     // Y position to teleport back to top
    public float startY = 10f;      // Y position to reset to

    void Update()
    {
        // Move downward
        transform.Translate(Vector2.down * scrollSpeed * Time.deltaTime);

        // When it scrolls off bottom, jump to the top
        if (transform.position.y <= resetY)
        {
            Vector3 pos = transform.position;
            pos.y = startY;
            transform.position = pos;
        }
    }
}
