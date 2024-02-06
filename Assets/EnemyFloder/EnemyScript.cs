using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Animator animator;
    PlayerMovment player;
    public Transform Ptransform;
    public Transform enemyTransform;
    [SerializeField] public Transform playerD;
    EnemyKnockback knock;
    public CapsuleCollider enemyCollider;
    public Rigidbody enemyRB;
     public float knockbackForce1 = 10f;
    public float knockbackForce2 = 10f;
    public float knockbackDuration = 0.5f;
    public float knockbackDeceleration = 2f;
    public float knockbackTimer;
    
    
    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      player = FindObjectOfType<PlayerMovment>();
      knock = FindObjectOfType<EnemyKnockback>();
      enemyCollider = GetComponent<CapsuleCollider>();
      enemyRB = GetComponent<Rigidbody>();
      
    }

     
     void Update()

    {


        if (knockbackTimer > 0)
        {
            // Update the knockback timer
            knockbackTimer -= Time.deltaTime;

            // Slow down the object over time for a smooth slide
              enemyRB.velocity -=    enemyRB.velocity * knockbackDeceleration * Time.deltaTime;

            // If the timer is up, reset the velocity and enable gravity
            if (knockbackTimer <= 0)
            {
                 enemyRB.velocity = Vector3.zero;
                 enemyRB.useGravity = true;
            }
        }

    }



    



    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Sword" && !player.animator.GetBool("SecondAttack") && !player.animator.GetBool("FifthAttack")){
            enemyTransform.rotation = Ptransform.rotation;
            animator.SetTrigger("GotHit");
            animator.SetBool("GotHit1", true);
            animator.SetBool("GotHit2", false);
            animator.SetBool("GotHit3", false);
            
            
            
             

           

            
        }
        if(other.gameObject.tag == "Sword" && player.animator.GetBool("SecondAttack"))
        {
            enemyTransform.rotation = Ptransform.rotation;
            animator.SetTrigger("GotHit");
            animator.SetBool("GotHit1", false);
            animator.SetBool("GotHit2", true);
            animator.SetBool("GotHit3", false);

           
        }

        if(other.gameObject.tag == "Sword" && player.animator.GetBool("FifthAttack"))
        {
            enemyTransform.rotation = Ptransform.rotation;
            animator.SetTrigger("GotHit");
            animator.SetBool("GotHit1", false);
            animator.SetBool("GotHit2", false);
            animator.SetBool("GotHit3", true);
            
        }


          if(!animator.GetBool("GotHit3"))
          {

               ApplyKnockback(playerD.forward);

          }

          else
          {

               ApplyKnockback2(playerD.forward);

          }

  
    }


    

     public void ApplyKnockback(Vector3 direction)
    {
        //if (knockbackTimer <= 0)
        //{ 

           

            // Disable the Rigidbody's gravity temporarily during knockback
           enemyRB.useGravity = false;

            // Calculate the knockback velocity based on the force and direction
            Vector3 knockbackVelocity = direction.normalized * knockbackForce1;

            // Apply the knockback force as an instantaneous change in velocity
             enemyRB.velocity = knockbackVelocity;

            // Start the knockback timer
            knockbackTimer = knockbackDuration;
        //}
    }

     public void ApplyKnockback2(Vector3 direction)
    {
        //if (knockbackTimer <= 0)
        //{ 

           

            // Disable the Rigidbody's gravity temporarily during knockback
           enemyRB.useGravity = false;

            // Calculate the knockback velocity based on the force and direction
            Vector3 knockbackVelocity = direction.normalized * knockbackForce2;

            // Apply the knockback force as an instantaneous change in velocity
             enemyRB.velocity = knockbackVelocity;

            // Start the knockback timer
            knockbackTimer = knockbackDuration;
        //}
    }


    


    


    void ReactFinish()
    {
        animator.SetBool("GotHit1", false);

    }
    void ReactFinish2()
    {
        animator.SetBool("GotHit2", false);

    }
    void ReactFinish3()
    {
        animator.SetBool("GotHit3", false);

    }





   
}
    

    


     
   

