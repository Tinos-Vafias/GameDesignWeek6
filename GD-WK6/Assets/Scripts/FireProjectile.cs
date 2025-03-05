//using UnityEditor.U2D.Sprites;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public static FireProjectile Instance { get; private set; }
    public GameObject fireballPrefab;
    public float spawnInterval = 2.0f;
    public float speed = 5.0f;
    private float timer = 0.0f;

    private float normalSpeed = 5.0f;
    private float normalInterval = 2.0f;
    
    private float minInterval = 0.3f;
    private float maxSpeed = 12.5f;

    bool startRandom = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= spawnInterval)
        {
            SpawnFireball();
            timer = 0.0f;
        }
    }

    void SpawnFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb2d = fireball.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.linearVelocity = new Vector2(-speed, 0);
        }
    }

    public void Combo()
    {
        if (!startRandom)
        {
            spawnInterval = Mathf.Clamp(spawnInterval - 0.1f, minInterval, 2.0f);
            speed = Mathf.Clamp(speed + 0.5f, 0.0f, maxSpeed);
        }
        else
        {
            spawnInterval = minInterval + Random.Range(0.0f, 0.25f);
            speed = maxSpeed + Random.Range(-2.0f, 2.0f);
        }
        if (speed == maxSpeed && spawnInterval == minInterval)
        {
            startRandom = true;
        }
    }
    public void ResetCombo()
    {
        spawnInterval = normalInterval;
        speed = normalSpeed;
        startRandom = false;
    }
}
