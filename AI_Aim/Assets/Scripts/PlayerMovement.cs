using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 500.0f;
    private float horizontalMovement;
    private float verticalMovement;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMovement * speed * Time.deltaTime, rb.velocity.y);

        verticalMovement = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, verticalMovement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
            Debug.Log("Player got hit");
    }
    
}
