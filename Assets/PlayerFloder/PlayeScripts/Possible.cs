using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possible : MonoBehaviour
{
    public bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other){
        if(other.gameObject.tag  == "Ground"){
            onGround = true;
        }       
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag  == "Ground"){
            onGround = false;
        }       
    }
}
