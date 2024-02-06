using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform cannon;
    public GameObject ball;
     [SerializeField] private float nextAttackTime = 0f;
     [SerializeField] private float attackRate = 1f;
     public bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        shooting();

        
        
    }

    private void shooting()
    {

        if(Time.time>=nextAttackTime){
        Instantiate(ball,cannon.position,transform.rotation);
        nextAttackTime=Time.time+1/attackRate;
        }

         

    }


     

}
