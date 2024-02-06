using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static Animator animator;
    // PlayerMovment player;
    PlayerJump jump;
    Vector3 dash = new Vector3(5,0,0);
    PlayerMovment playerScript;
    public AnimationClip dashz;
    private float dashCounter = 0;
    public float blendAttack;
    public bool isBlendAttack;
    public static PlayerCombat  instance;
    public float fallTimer = 0;
    public float fallTimerHeavy = 0;
    public float holdTimer = 0;
    public float battleTimer = 0;
    public bool startFallTimer;
    public bool startHoldTimer;
    public bool startBattleIdle;
    Possible colliderCheck;
    public bool isClicked;
    SwordScript sword;
    Shooting shoot;
    [SerializeField] GameObject projectile;
    [SerializeField] public Transform Weapon;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        jump = FindObjectOfType<PlayerJump>();
        playerScript = FindObjectOfType<PlayerMovment>();
        colliderCheck = FindObjectOfType<Possible>();
        instance = this;
        sword = FindObjectOfType<SwordScript>();
        shoot = FindObjectOfType<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Roll();
        Dash();
        JumpAttack();
        JumpAttackFall();
        JumpAttackHeavy();
        
        
        //HeavyJumpAttackFall();

        animator.SetFloat("Hold",holdTimer);

        if(startHoldTimer){
            holdTimer += Time.deltaTime;
        }

        if(startBattleIdle){
            battleTimer +=Time.deltaTime;
        }

        if(battleTimer > 0){
            animator.SetBool("battle", true);
        }else
        {
            animator.SetBool("battle", false);

        }

        if(battleTimer > 7)
        {
            battleTimer = 0;
            startBattleIdle = false;
        }

       

       
        
        
    }

    public void OnStateMove(){
        jump.fallSpeed.y =0;
    }

    public void JumpAttack(){
        if(Input.GetButton("Fire1") && jump.isGrounded == false && colliderCheck.onGround == false  &&  !isClicked)
        {
            animator.SetTrigger("JumpAttack");
            jump.fallSpeed.y = 15;
            startFallTimer = true;
            startBattleIdle = true;
            isClicked = true;
            battleTimer = 0;
            
        }
         
         
    }

    public void JumpAttackHeavy(){
        if(Input.GetButton("Fire2") && jump.isGrounded == false && colliderCheck.onGround == false  &&  !isClicked)
        {
            animator.SetTrigger("JumpAttackHeavy");
            jump.fallSpeed.y = 15;
            startFallTimer = true;
            startBattleIdle = true;
            isClicked = true;
            battleTimer = 0;
        }
         
         
    }

     void JumpAttackFall()
     {
        if(startFallTimer){
            fallTimer += Time.deltaTime;
        }

        if(jump.isGrounded){
            fallTimer = 0;
            startFallTimer = false;
        }

        if(fallTimer > 0f && fallTimer < 0.3f){
            jump.fallSpeed.y = 0;
            jump.gravity = 0;
        }
        
         if(fallTimer > 0.3f)
        {
            jump.gravity = -20;
             jump.fallSpeed.y = 15;

        }

     }

     void HeavyJumpAttackFall(){
         if(startFallTimer){
            fallTimerHeavy += Time.deltaTime;
        }

        if(jump.isGrounded){
            fallTimerHeavy = 0;
            startFallTimer = false;
        }

        if(fallTimerHeavy > 0f && fallTimerHeavy < 0.3f){
            jump.fallSpeed.y = 0;
            jump.gravity = 0;
        }
        
         if(fallTimerHeavy > 0.3f)
        {
            jump.gravity = -20;
             jump.fallSpeed.y = 15;

        }

        if(holdTimer > 0 || jump.isGrounded == false)
        {
            
            animator.ResetTrigger("JumpAttack");
            animator.ResetTrigger("JumpAttackHeavy");
        }

     }

    

    public void Roll()
    {
        if(holdTimer > 1 || holdTimer == 0)
        {  
         if(Input.GetKeyDown("left shift") && jump.isGrounded && !animator.GetBool("RollChack")){
            animator.SetTrigger("Doge");
            startBattleIdle = true;
             battleTimer = 0;
             sword.DeActiveteCollider();
             animator.ResetTrigger("LightAttackTrigger");
        }
        }

    
}
public void Dash()
{
     if(Input.GetKeyDown("left shift") && !jump.isGrounded && !animator.GetBool("IsRolling") && dashCounter ==0){
            dashCounter ++;
            animator.SetTrigger("Dash");
           
        }

        if(dashCounter == 1)
        {
            jump.gravity = 2.5f;
            jump.fallSpeed.y = -5f;
        }
        

        if(jump.isGrounded)
        {
            dashCounter = 0;
            isClicked = false;
        }
}


public void StopHold()
{
    startHoldTimer = false;
    holdTimer  = 0;
    jump.initialJumpVelocity = 20;

}

public void Shoot(){
        Instantiate(projectile,Weapon.position,transform.rotation);
    }

    public void ActiveRoll()
    {
        animator.SetBool("IsRolling",true);

    }



}


