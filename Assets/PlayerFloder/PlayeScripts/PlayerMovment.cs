using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class PlayerMovment : MonoBehaviour
{
    public CharacterController player;
    public  Animator animator;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public float velocity = 0.0f;
    float accelaration = 60f;
    float sprintAccelaration = 9f;
    float deceleration = 20f;
    private float doubleTapTimeWindow = 0.2f;
    private KeyCode lastKey = KeyCode.None;
    private KeyCode keyBefore = KeyCode.None;
    private float lastTapTime = 0f;
    public  bool isSptinting;
    private float runLimit = 4;
     public static PlayerMovment instance;
     PlayerJump jump;
     PlayerCombat combat;
     public int killCount = 0;
     public TMP_Text killText;
    
   
    
    
    

          

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); 
        jump = FindObjectOfType<PlayerJump>();
        combat = FindObjectOfType<PlayerCombat>();
        instance = this;
       
    }

    // Update is called once per frame
    void Update()
    {
   
         Walk();
         Sprint();
         SprintBlendControll();
         killText.text = killCount.ToString();  
    }


    public void Walk()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 diraction = new Vector3(horizontal,0f,vertical).normalized;

        if(diraction.magnitude >=0.1f && !animator.GetBool("IsRolling") && combat.holdTimer == 0 || combat.holdTimer > 1)
        {
            float targetAngle =Mathf.Atan2(diraction.x,diraction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity,turnSmoothTime);
            transform.rotation = Quaternion.Euler(0,angle,0);
            
            
            

            if(jump.isGrounded == false){
                Vector3 moveDir = Quaternion.Euler(0,targetAngle,0) * Vector3.forward;
            player.Move(moveDir.normalized * jump.airSpeed * Time.deltaTime);

            
            if(!jump.isJumping && jump.isGrounded && Input.GetButton("Jump"))
            {
                jump.isJumping = true;
                moveDir.y = jump.initialJumpVelocity;
                
            }    

            }


        }

        

       // This list of condotion control the velocity float valeu of the animator

        if (horizontal!=0 && velocity < runLimit ||  vertical!=0 && velocity < runLimit)
        {
            velocity += Time.deltaTime * accelaration;
        }

        if (horizontal==0 && velocity > 0.0f && vertical==0 && velocity > 0.0f)
        {
            velocity -= Time.deltaTime * deceleration;
        }

        if(isSptinting == false && velocity > 4.5)
        {
             velocity -= Time.deltaTime * deceleration;
        }

        if (horizontal==0 && velocity < 0.0f || vertical==0 && velocity < 0.0f)
        {
            velocity =0.0f;
        }

        
        animator.SetFloat("velocity",velocity);  
    }


     private void Sprint()
     {
         if(Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D)) 
        {
            CheckDoubleTap();
        }

    
    }


    
    private void CheckDoubleTap()

    {
        KeyCode currentKey = KeyCode.None;

        if (Input.GetKeyDown(KeyCode.W)) currentKey = KeyCode.W;
        if (Input.GetKeyDown(KeyCode.A)) currentKey = KeyCode.A;
        if (Input.GetKeyDown(KeyCode.S)) currentKey = KeyCode.S;
        if (Input.GetKeyDown(KeyCode.D)) currentKey = KeyCode.D;

        if (currentKey == lastKey && Time.time - lastTapTime < doubleTapTimeWindow)

        {
            isSptinting = true;
        }

        lastKey = currentKey;
        lastTapTime = Time.time;
    }

    public void SprintBlendControll()
    {
       
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

         if(isSptinting == true)
         {
            runLimit = 15;
            accelaration = sprintAccelaration;
         }

         else
         {
            runLimit = 4;
            accelaration = 50;
         }

           if(Input.GetKeyUp(lastKey))
            {
              isSptinting = false;
            }

             else if(Input.GetKey(KeyCode.W) && velocity > 7 || Input.GetKey(KeyCode.S) && velocity > 7
               || Input.GetKey(KeyCode.A) && velocity > 7|| Input.GetKey(KeyCode.D) && velocity > 7 )
            {
                isSptinting = true;
            }

    }

    


}




 





