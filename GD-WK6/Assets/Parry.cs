using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject targetObject;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (targetObject != null)
        {
            spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
            boxCollider = targetObject.GetComponent<BoxCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
 
        // Check if the spacebar is pressed.
        bool isSpacePressed = Input.GetKey(KeyCode.Space);

        // Enable or disable the SpriteRenderer.
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = isSpacePressed;
        }

        // Enable or disable the BoxCollider2D.
        if (boxCollider != null)
        {
            boxCollider.enabled = isSpacePressed;
        }

    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fireball")
        {
            Debug.Log("Parry");
            Destroy(other.gameObject);
        }
    }
}
