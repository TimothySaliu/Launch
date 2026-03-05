using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Shooting")]
    public GameObject bulletPrefab;       // Drag your Bullet prefab here
    public Transform firePoint;           // Empty child GameObject at the tip of the ship
    public float fireRate = 0.3f;         // Seconds between shots
    private float fireCooldown = 0f;

    [Header("Lives")]
    public int maxLives = 3;
    private int currentLives;

    [Header("Boundaries")]
    public float minX = -8f;
    public float maxX = 8f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; 
        currentLives = maxLives;

        // Update HUD
        UIManager.Instance?.UpdateLives(currentLives);
    }

    void Update()
    {
        if (!GameManager.Instance.isGameActive) return;

        HandleMovement();
        HandleShooting();
        ClampPosition();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D or Arrow keys
        float vertical = Input.GetAxisRaw("Vertical");     // W/S or Arrow keys

        Vector2 direction = new Vector2(horizontal, vertical).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    void HandleShooting()
    {
        fireCooldown -= Time.deltaTime;

        // Shoot with Spacebar or left mouse button
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("Bullet prefab or fire point not assigned!");
            return;
        }
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }

    /// <summary>Called when player is hit by an obstacle.</summary>
    public void TakeDamage()
    {
        currentLives--;
        UIManager.Instance?.UpdateLives(currentLives);
        Debug.Log("Player hit! Lives remaining: " + currentLives);

        if (currentLives <= 0)
        {
            GameManager.Instance.LoseGame();
        }
        else
        {
            // Flash effect to show damage (optional)
            StartCoroutine(FlashRed());
        }
    }

    System.Collections.IEnumerator FlashRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }
}
