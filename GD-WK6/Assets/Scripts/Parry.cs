using UnityEngine;
using System.Collections;
//using UnityEditor.ShaderGraph.Internal;

public class Parry : MonoBehaviour
{
    public static Parry Instance { get; private set; }
    public GameObject targetObject;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    
    private Animator anim;
    
    float timer = 0.0f;
    public bool isOn;

    public float parryCooldown = 0.1f;
    private bool canParry = true;
    private bool parried = false;
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

        //disable the sprite renderer and box collider on start
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        if (boxCollider != null)
            boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //parry has a cooldown
        timer += Time.deltaTime;
        if(timer > parryCooldown)
        {
            canParry = true;
        }
        // Check if the spacebar is pressed down (not held)
        if (Input.GetKeyDown(KeyCode.Space) && canParry)
        {
            StartParry();
            timer = 0.0f;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fireball")
        {
            Debug.Log("Parry");
            GameManager.Instance.AddCombo();
            //timer = 0;
            parried = true;
            Destroy(other.gameObject);
        }
    }
    
    public void Toggle()
    {
        isOn = !isOn;
    }
    public void PlayAnim()
    {
        if (isOn)
        {
            anim.SetBool("PlayAnim", true);
            anim.Play("ExplosionAnimation", 0, 0f); // Resets animation
        }
    }
    private void StartParry()
    {
        canParry = false;
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
        }
        // Start a coroutine to disable after 0.1 seconds
        StartCoroutine(DisableAfterTime(0.1f));
    }

    private IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        if (boxCollider != null)
            boxCollider.enabled = false;

        //parry cooldown is determined by whether or not you have successfully parried
        if (parried)
        {
            parryCooldown = 0.1f;
        }
        else
        {
            parryCooldown = 0.5f;
        }
        parried = false;
        anim.SetBool("PlayAnim", false);
    }
    
}
