using UnityEngine;

public class FireProjectile : MonoBehaviour
{

    public GameObject fireballPrefab;
    public float spawnInterval = 2.0f;
    public float speed = 5.0f;
    private float timer = 0.0f;

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
}
