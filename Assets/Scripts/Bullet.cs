using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Start()
    {
        // Auto-destroy after 3 seconds so bullets don't pile up
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // Move upward every frame
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            ObstacleScript obstacle = other.GetComponent<ObstacleScript>();
            if (obstacle != null)
                obstacle.TakeDamage(damage);

            Destroy(gameObject); // Bullet disappears on hit
        }
    }
}
