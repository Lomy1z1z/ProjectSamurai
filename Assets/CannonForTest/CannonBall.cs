using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonBall : MonoBehaviour
{
    Rigidbody ball;
    float LifeSpan = 0;
    [SerializeField] float ballSpeed;
    public GameObject slicedCannonBallHorizontal;
    public GameObject slicedCannonBallVertical;
    public Transform slicedCannonBallHorizontalTransform;
    Vector3 ballDir;
    PlayerMovment player;
    

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovment>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ballDir = transform.forward;
        ball.velocity =  ballDir * ballSpeed; 
        LifeSpan += Time.deltaTime;

        if(LifeSpan > 15){
            Destroy(gameObject);
            
        }
        
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(2);
        }
    }

    void OnTriggerEnter(Collider other){
         if(other.gameObject.tag == "Sword" && !player.animator.GetBool("ThirdAttack")){
            Destroy(gameObject);
            newBall();
        }
         if(other.gameObject.tag == "Sword" && player.animator.GetBool("ThirdAttack")){
            Destroy(gameObject);
            newBall2();
        }
    }

    public void newBall()
    {
        Instantiate(slicedCannonBallVertical,transform.position,transform.rotation);
    }
    public void newBall2()
    {
        Instantiate(slicedCannonBallHorizontal,transform.position,slicedCannonBallHorizontalTransform.rotation);
    }


   
}

