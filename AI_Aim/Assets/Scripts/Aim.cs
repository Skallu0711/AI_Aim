using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float shootTime = 1.0f;
    public float range = 5.0f;
    private float timer = 0.0f;
    private float distance;

    private Vector2 targetVector;

    public GameObject bullet;
    public GameObject target;

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        
        distance = Vector2.Distance(transform.position, target.transform.position);
        targetVector = target.transform.position;
        transform.LookAt(targetVector);
        
        Vector2 current = transform.position;
        var direction = targetVector - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (distance < range)
        {
            if (timer > shootTime)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        Debug.Log("Bullet spawned");
    }
    
}
