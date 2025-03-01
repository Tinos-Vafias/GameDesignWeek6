using System;
using UnityEngine;

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
            GameManager.Instance.ResetCombo();
            Destroy(other.gameObject);
            //Write something to play death animation and run below
            Debug.Log("Ouch! Collision");
        }
    }
}
