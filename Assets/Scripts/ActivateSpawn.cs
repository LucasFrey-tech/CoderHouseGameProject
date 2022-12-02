using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawn : MonoBehaviour
{   
    public GameObject spawn2, spawn3, spawn4, spawn5, spawn6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activate();
    }

   
       
        

    void activate(){
        if(GameObject.FindWithTag("Player").GetComponent<Character>().floor.name == "Floor" && (spawn2.GetComponent<EnemySpawn>().cantEnemies > 0 || spawn3.GetComponent<EnemySpawn>().cantEnemies > 0)){
            spawn2.SetActive(true);
            spawn3.SetActive(true);
            spawn2.GetComponent<MeshRenderer>().enabled = true;
            spawn2.GetComponent<EnemySpawn>().enabled = true;
            spawn3.GetComponent<MeshRenderer>().enabled = true;
            spawn3.GetComponent<EnemySpawn>().enabled = true;
        }else{
            spawn2.SetActive(false);
            spawn3.SetActive(false);
            if(GameObject.FindWithTag("Player").GetComponent<Character>().floor.name == "Floor2" && (spawn4.GetComponent<EnemySpawn>().cantEnemies > 0 || spawn5.GetComponent<EnemySpawn>().cantEnemies > 0 || spawn6.GetComponent<EnemySpawn>().cantEnemies > 0)){
                spawn4.SetActive(true);
                spawn5.SetActive(true);
                spawn6.SetActive(true);
                spawn4.GetComponent<MeshRenderer>().enabled = true;
                spawn5.GetComponent<MeshRenderer>().enabled = true;
                spawn6.GetComponent<MeshRenderer>().enabled = true;
                spawn4.GetComponent<EnemySpawn>().enabled = true;
                spawn5.GetComponent<EnemySpawn>().enabled = true;
                spawn6.GetComponent<EnemySpawn>().enabled = true;
            }else{
                spawn4.GetComponent<MeshRenderer>().enabled = false;
                spawn5.GetComponent<MeshRenderer>().enabled = false;
                spawn6.GetComponent<MeshRenderer>().enabled = false;
                spawn4.GetComponent<EnemySpawn>().enabled = false;
                spawn5.GetComponent<EnemySpawn>().enabled = false;
                spawn6.GetComponent<EnemySpawn>().enabled = false;
            }
        }


        return;
    }
}
