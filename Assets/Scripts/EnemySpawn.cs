using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{   
    public GameObject enemyPrefab, currentEnemy, floor;
    public float durationTime;
    float timeRun;
    float time;
    public int cantEnemies;
    
    // Start is called before the first frame update
    void Start()
    {   
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        time = durationTime;
    }

    // Update is called once per frame
    void Update()
    {   
        
        durationTime = timer();
        spawnEnemyAfterAWhile();
        deActivate();
        
    }

    float timer(){
        timeRun = Time.deltaTime;
        durationTime -= timeRun;
        return durationTime;
    }

    void spawnEnemyAfterAWhile(){
        if(!GameObject.FindWithTag("Enemy") && cantEnemies > 0 && durationTime <= 0){
            spawnEnemy();
            cantEnemies--;
        }else if(GameObject.FindWithTag("Enemy")){
            durationTime = time;
        }
        return;
    }

    void spawnEnemy(){
        currentEnemy = Instantiate(enemyPrefab);
        currentEnemy.GetComponent<Enemy>().mySpawn = gameObject;
        if(currentEnemy.GetComponent<Enemy>().mySpawn.name == "SeventhSpawn"){
            currentEnemy.transform.localScale *= 1.5f;
            currentEnemy.GetComponent<Enemy>().hitDamage = 30f;
        }
        currentEnemy.transform.position = gameObject.transform.position;
        currentEnemy.transform.rotation = gameObject.transform.rotation;
        return;
    }

    void deActivate(){
        if(cantEnemies <= 0 && !GameObject.FindWithTag("Enemy") && gameObject.name == "FirstEnemySpawn"){
            gameObject.GetComponent<EnemySpawn>().enabled = false;
            gameObject.SetActive(false);
        }
    }
    
}
