using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    public float timer = 0.0f;
    
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * 1 * speed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > 3.0f)
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("Bullet destroyed");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
           Destroy(gameObject); 
           Debug.Log("Bullet destroyed on collision with " + col.gameObject.tag);
        }
    }

#if UNITY_EDITOR

    private void OnValidate()
    {
        rb.velocity = transform.right * 1 * speed;
    }

#endif
    
}
