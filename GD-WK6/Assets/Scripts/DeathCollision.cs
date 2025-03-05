using System;
using UnityEngine;
using System.Collections; // Required for IEnumerator
using UnityEngine.SceneManagement;

public class DeathCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fireball")
        {

            GameManager.Instance.health = GameManager.Instance.health - (5 + 5*(GameManager.Instance.combo/20));
            GameManager.Instance.ResetCombo();

            //This currently does nothing, for whatever reason I couldn't get it to destroy itself after the animation
            other.gameObject.GetComponent<Animator>().SetBool("Explode", true);
            // Disable collider to prevent multiple collisions
            other.collider.enabled = false;

            //Damage is scaled based on the player's current combo count
            Destroy(other.gameObject);


            //Write something to play death animation and run below

            if (GameManager.Instance.health <= 0)
            {
                SceneManager.LoadScene("GameOverScreen");
            }
            Debug.Log("Ouch! Collision");
        }
    }
}
