using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardScript : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject ball2;
    [SerializeField] Transform wand;
     public Animator animator;
    PlayerMovment player;
    public Transform Ptransform;
    public Transform enemyTransform;
    [SerializeField] public Transform playerD;
    [SerializeField] public Transform playerChase;
    EnemyKnockback knock;
    public CapsuleCollider enemyCollider;
    public Rigidbody enemyRB;
     public float knockbackForce1 = 10f;
    public float knockbackForce2 = 10f;
    public float knockbackDuration = 0.5f;
    public float knockbackDeceleration = 2f;
    public float knockbackTimer;
    [SerializeField] Image hpImage;
    public float hp = 1f;
     [SerializeField] private float nextAttackTime = 0f;
     [SerializeField] private float attackRate = 1f;
     public float attackTimer;

    float rotationSpeed = 4;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
      player = FindObjectOfType<PlayerMovment>();
      knock = FindObjectOfType<EnemyKnockback>();
      enemyCollider = GetComponent<CapsuleCollider>();
      enemyRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer +=Time.deltaTime * 2;

        if(attackTimer > 10) attackTimer = 0;

        if(animator.GetBool("GotHit1")){
            attackTimer = 0; 
        }
        

         

        if(Time.time>=nextAttackTime && !animator.GetBool("GotHit1") && attackTimer > 5){
         AttackPlayer();
         nextAttackTime=Time.time+1/attackRate;
        }
         LookAtOnZAndX(target.position);
         

         

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

        
        hpImage.fillAmount = hp;

        if(hp <= 0.1){
            animator.SetBool("Dead",true);
        }

        
        
    }



     
    public void takeDMG(float DMG){
        hp -= DMG;
    }

    
         public void Hitten(){
             takeDMG(0.15f);
         }
    



    



    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Sword" && !player.animator.GetBool("SecondAttack") && !player.animator.GetBool("FifthAttack")){
            enemyTransform.rotation = Ptransform.rotation;
            animator.SetTrigger("GotHit");
            animator.SetBool("GotHit1", true);
            animator.SetBool("GotHit2", false);
            animator.SetBool("GotHit3", false);
            
            
            
            
            
            
            
             

           

            
        }
        if(other.gameObject.tag == "Sword" && player.animator.GetBool("SecondAttack") || player.animator.GetBool("FifthAttack") ||  player.animator.GetBool("SixthAttack"))
        {
            enemyTransform.rotation = Ptransform.rotation;
            animator.SetTrigger("GotHit");
            animator.SetBool("GotHit1", true);
            animator.SetBool("GotHit2", false);
            animator.SetBool("GotHit3", false);
           
            

           
        }

        // if(other.gameObject.tag == "Sword" && player.animator.GetBool("SixthAttack"))
        // {
        //     enemyTransform.rotation = Ptransform.rotation;
        //     animator.SetTrigger("GotHit");
        //     animator.SetBool("GotHit1", false);
        //     animator.SetBool("GotHit2", true);
        //     animator.SetBool("GotHit3", false);
            
           
            
        // }

        if(other.gameObject.tag == "Water")
        {
            enemyTransform.rotation = Ptransform.rotation;
            animator.SetTrigger("GotHit");
            animator.SetBool("GotHit1", false);
            animator.SetBool("GotHit2", true);
            animator.SetBool("GotHit3", false);
        }
        
        





           

        


          if(!animator.GetBool("Dead") && !player.animator.GetBool("FifthAttack") && other.gameObject.tag != "Water")
          {

               ApplyKnockback(playerD.forward);
               

               

          }

          else if( !animator.GetBool("Dead") /*&& animator.GetBool("GotHit2")*/ && player.animator.GetBool("FifthAttack"))
          {

               ApplyKnockback2(playerD.forward);
               

          }


           
           

          

          

  
    }


    

     public void ApplyKnockback(Vector3 direction)
    {
        //if (knockbackTimer <= 0)
       // { 

           

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


    
        void LookAtOnZAndX(Vector3 targetPosition)
    {
        // Calculate the direction to the target
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0f; // Set the y-component to zero to ignore vertical rotation

        // Check if the direction vector is not zero (to avoid division by zero)
        if (direction != Vector3.zero)
        {
            // Create a rotation based on the direction
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
        }

    }


    
    void ReactFinishZ()
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
        gameObject.SetActive(false);
        player.killCount += 1;
        
        

    }
    
    public void AttackPlayer(){
        animator.SetBool("Skill",true);
        Instantiate(ball,playerD.position,transform.rotation);
        nextAttackTime=Time.time+1/attackRate;
        
    }

    public void ResetAttack(){
        animator.SetBool("Skill",false);
        
    }
}
