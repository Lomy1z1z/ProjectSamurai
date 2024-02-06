using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    Vector3 shotDir;
    Rigidbody shot;
    float lifespan;
    // Start is called before the first frame update
    void Start()
    {
        shot = GetComponent<Rigidbody>();
        lifespan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        shotDir = transform.forward;
        shot.velocity = shotDir * 10;
        lifespan += Time.deltaTime;

        if(lifespan > 3 ){
            Destroy(gameObject);
        }
        

        
    }

    
}
