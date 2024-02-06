using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    Animator animator;
    public BoxCollider swordCollder;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    public void ActiveCollider(){
        swordCollder.enabled = true;
    }
    
    public void DeActiveteCollider(){
        swordCollder.enabled = false;
    }
}
