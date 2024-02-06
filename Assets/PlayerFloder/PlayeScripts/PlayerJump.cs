using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public static Animator animator;
    public float gravity = -9.81f;
   public float groundedGravity =- .05f;
    public bool isGrounded;
    public float airSpeed = 0 ;
     public float initialJumpVelocity;
    public float maxJumpHight = 10f;
    public float maxJumpTime = 2f;
    public bool isJumping = false;
    public Vector3 jump = new Vector3(0,0,0);
    public float JumpTimer = 0;
    public Vector3 fallSpeed;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform groundChack;
    public float jumpCount = 0;
    public float fallMultiplier;
    public static PlayerJump instance;
    PlayerMovment playerScript;
    PlayerCombat comb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerScript = FindObjectOfType<PlayerMovment>();
        instance = this;
        comb = FindObjectOfType<PlayerCombat>();
        
    }

    // Update is called once per frame
    void Update()
    {
         Jump();
         DoubleJump();
         
    }

    void Awake()
    {
         setupJumpVaribelse();

    }
    

     void setupJumpVaribelse()
        {

            float timeToApex = maxJumpTime / 2f;
            gravity = (-2 * maxJumpHight) / Mathf.Pow(timeToApex , 2);
            initialJumpVelocity = (2 * maxJumpHight) / timeToApex;
        }

        void hundleJump()
        {
            if(comb.holdTimer == 0 || comb.holdTimer > 1){
            if(!isJumping && isGrounded && Input.GetButtonDown("Jump") && !animator.GetBool("RollChack"))
            {
                isJumping = true;
                jump.y = initialJumpVelocity * .5f;
                animator.SetTrigger("jumpTrigger"); 
            }
            

             else if(!Input.GetButtonDown("Jump") && isJumping && isGrounded)
             {
                 isJumping = false; 
                 

             }
            }
        }

        void hundleGravity(){
            bool isFalling = jump.y <= 0.0f || JumpTimer > 0.7f;
             fallMultiplier = fallSpeed.y;
            if(isGrounded && fallSpeed.y !=0)
            {

             jump.y = groundedGravity;
             
            }else if (isFalling){

                float prevJumpVelocity = jump.y;
                float newJumpVelocity =  jump.y + (gravity * fallMultiplier * Time.deltaTime);
                float nextJumpVelocity = Mathf.Max((prevJumpVelocity + newJumpVelocity) * .5f, -20f);
                jump.y = nextJumpVelocity;
                

            }
            else

            {
                float prevJumpVelocity = jump.y;
                float newJumpVelocity = jump.y + (gravity * Time.deltaTime);
                float nextJumpVelocity = (prevJumpVelocity + newJumpVelocity) * .5f;
                jump.y = nextJumpVelocity;

            }

 

            
         }

         

         
         
         public void Jump()

         {

            animator.SetFloat("FallSpeed", fallSpeed.y);

            
            
                isGrounded = Physics.CheckSphere(groundChack.position, groundDistance,groundMask);
            
           
           


             
            
            

         hundleGravity();
           hundleJump();



        


           if(!animator.GetBool("SixthAttack"))
           {
             playerScript.player.Move(jump * Time.deltaTime);
           }

         if(isGrounded)
         {
            animator.SetBool("Grounded", true);  
         }
         if(!isGrounded)
         {
            animator.SetBool("Grounded", false);
         }


         if(isJumping)
         {
            JumpTimer += Time.deltaTime;
         }

         if(isGrounded){
            JumpTimer = 0;
            gravity = -20f;
         }

         

          if(isGrounded)
          {
             fallSpeed.y = 0;
          }
         
          else
         {
              fallSpeed.y -= gravity * Time.deltaTime * 0.14f;
              
         }

         if(!isGrounded && playerScript.velocity > 7)
         {
            airSpeed = 8.1f;
         }
         else 
         {
            airSpeed = 5.15f;
         }

         if(!isGrounded)
         {
            isJumping = true;
         }

         }

         

         private void DoubleJump(){

        
        if(isGrounded)
        {
            jumpCount = 0;
        }
            if(Input.GetButtonDown("Jump") &&  isGrounded == false){
                jumpCount ++;
            }

            if(Input.GetButtonDown("Jump") && jumpCount == 1  && !animator.GetBool("doubleJumpBool")){
                isJumping = true;
                jump.y = initialJumpVelocity * 0.62f;
                animator.SetTrigger("doubleJump");
                
 
            }
            
}






}
