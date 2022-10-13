using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{   
    public GameObject player;
    public float maxDistance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        checkDistance();
        lookAtPlayer();
        moveToPlayer();
    }
    
    void lookAtPlayer(){
        transform.LookAt(player.transform.position);

        return;
    }

    void moveToPlayer(){
        transform.position = Vector3.Lerp(transform.position,player.transform.position, speed * Time.deltaTime);
        
        return;
    }

    void checkDistance(){
        float distance = Vector3.Distance(transform.position,player.transform.position);

        if(distance > maxDistance){
            speed = 1f;
        }else{
            speed = 0f;
        }

        return;
    }
}
