using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
   {
    public float knockbackForce1 = 10f;
    public float knockbackForce2 = 10f;
    public float knockbackDuration = 0.5f;
    public float knockbackDeceleration = 2f;
    public float knockbackTimer;

    public Rigidbody rb;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    void Update()
    {
        if (knockbackTimer > 0)
        {
            // Update the knockback timer
            knockbackTimer -= Time.deltaTime;

            // Slow down the object over time for a smooth slide
            rb.velocity -= rb.velocity * knockbackDeceleration * Time.deltaTime;

            // If the timer is up, reset the velocity and enable gravity
            if (knockbackTimer <= 0)
            {
              rb.velocity = Vector3.zero;
              rb.useGravity = true;
            }
        }
    }

    public void ApplyKnockback(Vector3 direction,Rigidbody body)
    {
        // if (knockbackTimer <= 0)
        // {

            rb = body;

            // Disable the Rigidbody's gravity temporarily during knockback
            body.useGravity = false;

            // Calculate the knockback velocity based on the force and direction
            Vector3 knockbackVelocity = direction.normalized * knockbackForce1;

            // Apply the knockback force as an instantaneous change in velocity
             body.velocity = knockbackVelocity;

            // Start the knockback timer
            knockbackTimer = knockbackDuration;
        //}
    }

    public void ApplyKnockback2(Vector3 direction,Rigidbody body)
    {
        //if (knockbackTimer <= 0)
        //{ 

            rb = body;

            // Disable the Rigidbody's gravity temporarily during knockback
           body.useGravity = false;

            // Calculate the knockback velocity based on the force and direction
            Vector3 knockbackVelocity = direction.normalized * knockbackForce2;

            // Apply the knockback force as an instantaneous change in velocity
           body.velocity = knockbackVelocity;

            // Start the knockback timer
            knockbackTimer = knockbackDuration;
        //}
    }

    
}
