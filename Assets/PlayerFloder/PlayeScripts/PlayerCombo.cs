using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCombo : MonoBehaviour
{
    Animator animator;
    PlayerJump jump;
    [SerializeField] Transform enemyTransform;
     public Transform player;
    public float rotationSpeed = 5f;
    EnemyMovmentMInotaur mino;
    
    private Transform targetEnemy;
    public bool close;
    PauseMenu test;
    [SerializeField] GameObject text;
    public Transform areaChack;
     public float areaDistance;
    public LayerMask areaTrigger;
    PlayerCombat combat;
    public  ParticleSystem vfx1;
    public  ParticleSystem vfx2;
    public  ParticleSystem vfx3;
    public  ParticleSystem vfx4;
    public  ParticleSystem vfx5;
    public  ParticleSystem vfx6;
    public static PlayerCombo instance;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        jump = FindObjectOfType<PlayerJump>();
        mino = FindObjectOfType<EnemyMovmentMInotaur>();
        combat = FindObjectOfType<PlayerCombat>();
        test = FindObjectOfType<PauseMenu>();
        instance = this;
        
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && jump.isGrounded == true  && !animator.GetBool("IsRolling") && !animator.GetBool("SixthAttack")){
            animator.SetTrigger("LightAttackTrigger");
             // Find the nearest enemy within a certain range
            targetEnemy = FindNearestEnemy();
            combat.startBattleIdle = true;
             combat.battleTimer = 0;
           
        }

         close = Physics.CheckSphere(areaChack.position, areaDistance,areaTrigger);
         
         

        


        if(close == true && !animator.GetBool("IsRolling")  && !animator.GetBool("SixthAttack") && Attacks())
        {
            RotateTowardsTarget();
          

        } 

       
        
        
        

        

        
       
    }

    public bool Attacks(){
        return
         animator.GetBool("FirstAttack") ||
         animator.GetBool("SecondAttack") || 
         animator.GetBool("ThirdAttack") ||
         animator.GetBool("ForthAttack") ||
         animator.GetBool("FifthAttack");
    }

    

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Axe"){

            //test.ResatrtLevel();
            SceneManager.LoadScene(2);
            //Debug.Log("GotHit");
        }

        if(other.gameObject.tag == "Fin")
        {
            text.SetActive(true);

        }
    }


     Transform FindNearestEnemy()
    {
        // Implement your logic to find the nearest enemy (e.g., within a certain radius)
        // You might use Physics.OverlapSphere or other methods depending on your game setup

        // For illustration purposes, let's assume enemies have a "Enemy" tag
        Collider[] colliders = Physics.OverlapSphere(player.position, 10f, LayerMask.GetMask("Enemy"));

        if (colliders.Length > 0)
        {
            Transform nearestEnemy = colliders[0].transform;
            float minDistance = Vector3.Distance(player.position, nearestEnemy.position);

            foreach (var collider in colliders)
            {
                float distance = Vector3.Distance(player.position, collider.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = collider.transform;
                }
            }

            return nearestEnemy;
        }

        return null;
    }

    void RotateTowardsTarget()
    {
        if (targetEnemy != null)
        {
            // Calculate the direction to the target
            Vector3 direction = targetEnemy.position - player.position;
            direction.y = 0; // Keep the rotation only in the horizontal plane

            // Rotate the player to face the target
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            player.rotation = Quaternion.Slerp(player.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void FirstFinish(){
        animator.SetBool("FirstAttackFinish",true);
    }
    public void ScondFinish(){
        animator.SetBool("ScondAttackFinish",true);
    }
    public void ThirdFinish(){
        animator.SetBool("ThirdAttackFinish",true);
    }
    public void ForthFinish(){
        animator.SetBool("ForthAttackFinish",true);
    }
    public void FiftFinish(){
        animator.SetBool("FifthAttackFinish",true);
    }

    public void Vfx1()
    {
        PlayerCombo.instance.vfx1.Play();
    }
    public void Vfx2()
    {
        PlayerCombo.instance.vfx2.Play();
    }
    public void Vfx3()
    {
        PlayerCombo.instance.vfx3.Play();
    }
    public void Vfx4()
    {
        PlayerCombo.instance.vfx4.Play();
    }
    public void Vfx5()
    {
        PlayerCombo.instance.vfx5.Play();
    }
    public void Vfx6()
    {
        PlayerCombo.instance.vfx6.Play();
    }
    

    public void DisableRotation(){
        rotationSpeed = 0;
    }

   

 
   

    
}
