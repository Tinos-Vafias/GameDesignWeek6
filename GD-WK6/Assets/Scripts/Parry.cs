using UnityEngine;

public class Parry : MonoBehaviour
{
    public GameObject targetObject;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    
    private Animator anim;
    
    float timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (targetObject != null)
        {
            spriteRenderer = targetObject.GetComponent<SpriteRenderer>();
            boxCollider = targetObject.GetComponent<BoxCollider2D>();
            anim = GetComponent<Animator>();
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

        timer += Time.deltaTime;
        if (timer > .2)
        {
            anim.SetBool("PlayAnim", false);
        }
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fireball")
        {
            Debug.Log("Parry");
            GameManager.Instance.AddCombo();

            timer = 0;
            anim.SetBool("PlayAnim", true);
            Destroy(other.gameObject);
        }
    }
}
