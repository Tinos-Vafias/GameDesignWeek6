using System;
using UnityEngine;

public class playExplosionAnim : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fireball")
        {
            Debug.Log(other.gameObject.name);
            anim.Play("Explode");
        }
    }
}
