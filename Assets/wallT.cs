using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallT : MonoBehaviour
{
    public GameObject fullWall; 
    public GameObject leftWall; 
    public GameObject rightWall; 
    PlayerMovment player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovment>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Water" && player.killCount == 10)  {
            fullWall.SetActive(false);
            leftWall.SetActive(true);
            rightWall.SetActive(true);
        }
    }
}
