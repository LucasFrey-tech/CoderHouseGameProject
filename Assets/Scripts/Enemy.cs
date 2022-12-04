using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{   
    public float health = 100f;
    public GameObject healthBarUI;
    public Slider slider;
    public float enemyMaxHealth = 100f;

    public float hitDamage = 15f;
    public GameObject objective, mySpawn, floor;
    Quaternion lookOnPlayer;
    Rigidbody rb;
    public float maxDistance;
    public float speed;
    Animator anim;
    BoxCollider fists;
    public float timer = 0f;
    float time = 0.1f;
    bool grounded = true;
    
    // Start is called before the first frame update
    void Start()
    {   
        healthBarUI = gameObject.transform.GetChild(3).gameObject;
        slider = healthBarUI.transform.GetChild(0).gameObject.GetComponent<Slider>();
        activateUI();
        floor = mySpawn.GetComponent<EnemySpawn>().floor;
        anim = GetComponent<Animator>();
        fists = gameObject.transform.GetChild(1).GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(5).GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {   

        slider.value = health / enemyMaxHealth;

        if(GameObject.FindWithTag("Player")){
            objective = GameObject.FindWithTag("Player");
            rb = objective.GetComponent<Rigidbody>();  
        }else{
            objective = null;
            rb = null;
        }
        
        if(!anim.GetBool("IsDying")){
            if(objective != null && objective.GetComponent<Character>().floor == floor && grounded){
                lookAtPlayer();
                checkDistance();
                moveToPlayer();
            }else{
                noAttack();
                noRunning();
            }

        }

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

    }
    
    void OnCollisionExit(Collision enemy){
        if(enemy.gameObject.transform.tag == "Floor"){
            grounded = false;
        }else{
            grounded = true;
        }
    }

    void checkDistance(){
        float distance = Vector3.Distance(objective.transform.position,transform.position);

        if(distance > maxDistance){
            speed = 0.5f;
            noAttack();
            Running();
            timer = time;
        }else{
            speed = 0f;
            if(!anim.GetBool("IsAttacking")){
                timer -= Time.deltaTime;    
            }

            if(timer <= 0f){
                noRunning();
                attack();
            }
        }

        return;
    }

    void moveToPlayer(){
        transform.position = Vector3.Lerp(transform.position,objective.transform.position, speed * Time.deltaTime);
        return;
    }

    void Running(){
        anim.SetBool("IsRunning", true);
        return;
    }

    void noRunning(){
        anim.SetBool("IsRunning", false);
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
            deactivateUI();
            anim.SetBool("IsDying", true);
            if(mySpawn.name == "SeventhSpawn"){
                GameObject.FindWithTag("Win").GetComponent<AttachPlayer>().bossDefeated = true;
            }
            Destroy(gameObject,3f);
        }else{
            anim.SetBool("IsDying", false);
        }
        return;
    }


    void deactivateUI(){
        healthBarUI.SetActive(false);
        return;
    }

    void activateUI(){
       healthBarUI.SetActive(true);
        return;
    }

}
