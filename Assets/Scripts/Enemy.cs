using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public float health = 100f;
    public float hitDamage = 15f;
    public GameObject objective, mySpawn;
    Quaternion lookOnPlayer;
    Rigidbody rb;
    public float maxDistance;
    public float speed;
    Animator anim;
    BoxCollider fists;
    public float timer = 0f;
    float time = 0.1f;
    
    
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

        death();
    }

    void lookAtPlayer(){
        lookOnPlayer = Quaternion.LookRotation(objective.transform.position - new Vector3(transform.position.x,objective.transform.position.y,transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookOnPlayer, Time.deltaTime);
        return;
    }

    
    void OnCollisionStay(Collision enemy){
        if(enemy.transform.gameObject.tag == "Respawn"){
            health = 0;
        }
        if(enemy.transform.gameObject.tag == "Floor" || enemy.transform.gameObject.tag == "EnemySpawn"){
            lookAtPlayer();
            checkDistance();
            moveToPlayer();
        }

    }
    

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
        fists.enabled = true;
        timer = time;
        return;
    }

    void noAttack(){
        anim.SetBool("IsAttacking", false);
        fists.enabled = false;
        return;
    }

    void death(){
        if(health <= 0){
            Destroy(gameObject,3f);
        }
        return;
    }
}
