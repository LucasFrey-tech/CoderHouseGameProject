using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{   
    public GameObject enemyPrefab, currentEnemy;
    public float durationTime;
    float timeRun;
    float time;
    
    // Start is called before the first frame update
    void Start()
    {   
        time = durationTime;
    }

    // Update is called once per frame
    void Update()
    {   
        
        durationTime = timer();
        spawnEnemyAfterAWhile();
        
        
    }

    float timer(){
        timeRun = Time.deltaTime;
        durationTime -= timeRun;
        return durationTime;
    }

    void spawnEnemyAfterAWhile(){
        if(!GameObject.FindWithTag("Enemy") && durationTime <= 0){
            spawnEnemy();
        }else if(GameObject.FindWithTag("Enemy")){
            durationTime = time;
        }
        
        return;
    }

    void spawnEnemy(){
        currentEnemy = Instantiate(enemyPrefab);
        currentEnemy.transform.position = gameObject.transform.position;
        return;
    }

}
