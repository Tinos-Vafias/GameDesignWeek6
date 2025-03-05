using UnityEngine;

public class Parry : MonoBehaviour
{
    public static Parry Instance { get; private set; }
    public GameObject targetObject;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    
    private Animator anim;
    
    float timer;
    public bool isOn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps it alive between scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates
        }
        
        
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

            if (isOn == true)
            {
                anim.SetBool("PlayAnim", true);
            }
            
            timer = 0;
            Destroy(other.gameObject);
        }
    }
    
    public void Toggle()
    {
        isOn = !isOn;
    }
    public void PlayAnim()
    {
        anim.SetBool("PlayAnim", true);
    }
}
