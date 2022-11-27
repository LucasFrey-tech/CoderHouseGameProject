using System.Threading;
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
    Animator anim;
    BoxCollider fists;
    public float timer = 0;
    float time = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {   
        anim = GetComponent<Animator>();
        fists = gameObject.transform.GetChild(1).GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(5).GetComponent<BoxCollider>();
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

    /*void OnCollisionStay(Collision enemy){
        if(enemy.transform.gameObject.tag == "Player"){
            rb.AddForce(objective.transform.forward * -10, ForceMode.Impulse);
            objective.GetComponent<Character>().health -= hitDamage;
        }
    }
    */

    void checkDistance(){
        float distance = Vector3.Distance(objective.transform.position,transform.position);

        if(distance > maxDistance){
            speed = 0.5f;
            noAttack();
            timer = time;
        }else{
            speed = 0f;
            if(!anim.GetBool("IsAttacking")){
                timer -= Time.deltaTime;    
            }

            if(timer <= 0f){
                attack();
            }
        }

        return;
    }

    void moveToPlayer(){
        transform.position = Vector3.Lerp(transform.position,objective.transform.position, speed * Time.deltaTime);
        return;
    }

    void attack(){
        anim.SetBool("IsAttacking", true);
        timer = time;
        return;
    }

    void noAttack(){
        anim.SetBool("IsAttacking", false);
        return;
    }

}
