using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testz : MonoBehaviour
{
    
    Rigidbody box;
    float boxSpeed = 10;
    WizardScript wiz;
    // Start is called before the first frame update
    void Start()
    {
        box =GetComponent<Rigidbody>();
        wiz = FindObjectOfType<WizardScript>();

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position,wiz.playerChase.position,boxSpeed * Time.deltaTime);

        if(wiz.animator.GetBool("Skill") == true){
            boxSpeed = 10;
        }else{
            boxSpeed = 0;
            Invoke("DestroyGO",0.5f); 
        }

        if(wiz.animator.GetBool("GotHit1")){
            gameObject.SetActive(false);

        }
        
    
}

private void DestroyGO(){
    gameObject.SetActive(false);
}


}
