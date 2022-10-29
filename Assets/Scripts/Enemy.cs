using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float health = 100f;
    public float hitDamage = 15f;
    public GameObject objective;
    Quaternion lookOnPlayer;
    Rigidbody rb;
    public float maxDistance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        objective = GameObject.FindWithTag("Player");
        rb = objective.GetComponent<Rigidbody>();  
        lookAtPlayer();
        checkDistance();
        moveToPlayer();
        if(health <= 0){
            Destroy(gameObject,3f);
        }
    }

    void lookAtPlayer(){
        lookOnPlayer = Quaternion.LookRotation(objective.transform.position - new Vector3(transform.position.x,objective.transform.position.y,transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookOnPlayer, Time.deltaTime);
        return;
    }

    void OnCollisionStay(Collision enemy){
        if(enemy.transform.gameObject.tag == "Player"){
            rb.AddForce(objective.transform.forward * -10, ForceMode.Impulse);
            objective.GetComponent<Character>().health -= hitDamage;
        }
    }

    void checkDistance(){
        float distance = Vector3.Distance(transform.position,objective.transform.position);

        if(distance > maxDistance){
            speed = 0.5f;
        }else{
            speed = 0f;
        }

        return;
    }

    void moveToPlayer(){
        transform.position = Vector3.Lerp(transform.position,objective.transform.position, speed * Time.deltaTime);
        return;
    }

}
