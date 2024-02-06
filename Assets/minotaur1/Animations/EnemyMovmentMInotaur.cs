using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovmentMInotaur : MonoBehaviour
{
    public MinotaurScript body;
    PlayerJump jump;
    [SerializeField] Transform target;
    public float enemyStep = 2;
    Animator animator;
    bool isStop = false;
    float rotationSpeed = 4;
    public Transform areaChack;
     public float areaDistance;
    public LayerMask areaTrigger;
    bool startChase;
    public int solo;
    public bool isRunAttack;
    public static EnemyMovmentMInotaur instance;
    public bool chack;
    

    [SerializeField] SphereCollider axe;
    // Start is called before the first frame update
    void Start()
    {
        body = FindObjectOfType<MinotaurScript>();
        animator = GetComponent<Animator>();
        jump = FindObjectOfType<PlayerJump>();
        instance = this;
       
    }

    // Update is called once per frame
    void Update()
    {
        
         if(!animator.GetBool("GotHit1") &&  !animator.GetBool("GotHit2") && !animator.GetBool("GotHit3") && enemyStep > 0 && startChase)
         {
          transform.position = Vector3.MoveTowards(transform.position, target.position,enemyStep * Time.deltaTime);
          animator.SetBool("walk",true);
         }else
         {
            animator.SetBool("walk",false);

         }

          if (target != null && startChase)
        {
            LookAtOnZAndX(target.position);
        }

        if(animator.GetBool("GotHit1") ||  animator.GetBool("GotHit2") || animator.GetBool("GotHit3"))
        {

            animator.ResetTrigger("Attack");
            animator.ResetTrigger("runAttack");

        }

       
        //    if(startChase && !animator.GetBool("GotHit1") &&  !animator.GetBool("GotHit2") && !animator.GetBool("GotHit3") && body.enemyRB.isKinematic == false){
        //      solo = RunAttack(0);
            
        //     Debug.Log(solo);
        //    }
        

        // if(solo == 5){
        //     isRunAttack = true;
        //     areaDistance = 20;
        // }

        // if(isRunAttack && !animator.GetBool("Kick"))
        // {
        //     enemyStep = 10;
        // }
            
        
    


        startChase = Physics.CheckSphere(areaChack.position, areaDistance,areaTrigger);

       



        

       
        


  
   
             
             
  

            

        

        

           animator.SetFloat("EnemyStep",enemyStep);
         
  
     }
    
      void OnTriggerEnter(Collider other){
          if(other.gameObject.tag == "border" && !animator.GetBool("GotHit1") &&  !animator.GetBool("GotHit2") && !animator.GetBool("GotHit3") && !isRunAttack){

            body.enemyRB.isKinematic = true;
            enemyStep = 0;
             animator.SetTrigger("Attack");
          }
         
             
        //   if(other.gameObject.tag == "border" && !animator.GetBool("GotHit1") &&  !animator.GetBool("GotHit2") && !animator.GetBool("GotHit3") && isRunAttack){

        //     body.enemyRB.isKinematic = true;
        //     enemyStep = 0;
        //      animator.SetTrigger("runAttack");
             
        //   }

      }

    
      

       void OnTriggerExit(Collider other){
            if(other.gameObject.tag == "border"){

                body.enemyRB.isKinematic = false;
                enemyStep = 2;
                animator.ResetTrigger("Attack");
                animator.ResetTrigger("runAttack");
                
            }
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

    void ActiveAxe(){

        axe.enabled = true;


    }

    void DeActiveAxe(){

        axe.enabled = false;


    }

    void DeRunAttack(){

        isRunAttack = false;
        areaDistance = 10;


    }
    public int RunAttack(int num){

        num = Random.Range(1,500);

        return num;

        
    }

       


}

