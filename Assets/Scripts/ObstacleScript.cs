using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [Header("Stats")]
    public int health = 1;
    public int scoreValue = 10; // Points given when destroyed
    public float fallSpeed = 3f;

    void Start()
    {
        // Speed is boosted by the current difficulty multiplier
        fallSpeed *= GameManager.Instance.difficultyMultiplier;
    }

    void Update()
    {
        // Move downward
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Destroy if below screen (missed by player — no penalty, just clean up)
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyObstacle();
        }
    }

    void DestroyObstacle()
{
    GameManager.Instance.AddScore(scoreValue);
    
    // Tell the spawner an obstacle was destroyed
    ObstacleSpawner spawner = FindFirstObjectByType<ObstacleSpawner>();
    if (spawner != null)
        spawner.OnObstacleDestroyed();
    
    Destroy(gameObject);
}
}
