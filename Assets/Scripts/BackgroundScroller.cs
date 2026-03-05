using UnityEngine;


public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetY = -10f;
    public float startY = 10f;
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
