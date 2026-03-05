using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject[] obstaclePrefabs;  // Drag 1 or more obstacle prefabs here
    public float baseSpawnRate = 1.5f;    // Seconds between spawns at start
    public float minSpawnRate = 0.3f;     // Fastest possible spawn rate

    [Header("Spawn Area")]
    public float minX = -8f;
    public float maxX = 8f;

    private float spawnTimer = 0f;

    [Header("Win Condition")]
    public int obstaclesRequiredToWin = 50; // Destroy this many to win
    private int obstaclesDestroyed = 0;

    void Update()
    {
        if (!GameManager.Instance.isGameActive) return;

        spawnTimer += Time.deltaTime;

        // Calculate current spawn interval (gets faster with difficulty)
        float currentSpawnRate = Mathf.Max(
            minSpawnRate,
            baseSpawnRate / GameManager.Instance.difficultyMultiplier
        );

        if (spawnTimer >= currentSpawnRate)
        {
            SpawnObstacle();
            spawnTimer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0)
        {
            Debug.LogWarning("No obstacle prefabs assigned to spawner!");
            return;
        }

        // Pick a random obstacle type
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);

        // Spawn at random X position above the screen
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

        Instantiate(obstaclePrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }

    /// <summary>Call this from ObstacleScript when an obstacle is destroyed.</summary>
    public void OnObstacleDestroyed()
    {
        obstaclesDestroyed++;

        if (obstaclesDestroyed >= obstaclesRequiredToWin)
        {
            GameManager.Instance.WinGame();
        }
    }
}
