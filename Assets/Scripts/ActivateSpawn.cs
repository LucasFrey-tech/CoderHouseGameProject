using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawn : MonoBehaviour
{   
    public GameObject spawn2, spawn3, spawn4, spawn5, spawn6, spawn7;
    public bool deActivated = false;
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
        if(GameObject.FindWithTag("Player") && GameObject.FindWithTag("Player").GetComponent<Character>().floor && GameObject.FindWithTag("Player").GetComponent<Character>().floor.name == "Floor"){
            spawn2.SetActive(true);
            spawn3.SetActive(true);
            if((spawn2.GetComponent<EnemySpawn>().cantEnemies > 0 || spawn3.GetComponent<EnemySpawn>().cantEnemies > 0)){
                spawn2.GetComponent<MeshRenderer>().enabled = true;
                spawn2.GetComponent<EnemySpawn>().enabled = true;
                spawn3.GetComponent<MeshRenderer>().enabled = true;
                spawn3.GetComponent<EnemySpawn>().enabled = true;
            }else{
                spawn2.SetActive(false);
                spawn3.SetActive(false);
            }

        }else{
            if(spawn2 && spawn3){
                spawn2.SetActive(false);
                spawn3.SetActive(false);
            }
            if(GameObject.FindWithTag("Player") && GameObject.FindWithTag("Player").GetComponent<Character>().floor && GameObject.FindWithTag("Player").GetComponent<Character>().floor.name == "Floor2"){
                spawn4.SetActive(true);
                spawn5.SetActive(true);
                spawn6.SetActive(true);
                if((spawn4.GetComponent<EnemySpawn>().cantEnemies > 0 || spawn5.GetComponent<EnemySpawn>().cantEnemies > 0 || spawn6.GetComponent<EnemySpawn>().cantEnemies > 0)){
                    spawn4.GetComponent<MeshRenderer>().enabled = true;
                    spawn5.GetComponent<MeshRenderer>().enabled = true;
                    spawn6.GetComponent<MeshRenderer>().enabled = true;
                    spawn4.GetComponent<EnemySpawn>().enabled = true;
                    spawn5.GetComponent<EnemySpawn>().enabled = true;
                    spawn6.GetComponent<EnemySpawn>().enabled = true;
                }else if(!GameObject.FindWithTag("Enemy") || GameObject.FindWithTag("Enemy") && (GameObject.FindWithTag("Enemy").GetComponent<Enemy>().mySpawn.name != "ForthSpawn" && GameObject.FindWithTag("Enemy").GetComponent<Enemy>().mySpawn.name != "FifthSpawn" && GameObject.FindWithTag("Enemy").GetComponent<Enemy>().mySpawn.name != "SixthSpawn")){
                    spawn4.GetComponent<MeshRenderer>().enabled = false;
                    spawn5.GetComponent<MeshRenderer>().enabled = false;
                    spawn6.GetComponent<MeshRenderer>().enabled = false;
                    spawn4.GetComponent<EnemySpawn>().enabled = false;
                    spawn5.GetComponent<EnemySpawn>().enabled = false;
                    spawn6.GetComponent<EnemySpawn>().enabled = false;
                    spawn4.SetActive(false);
                    spawn5.SetActive(false);
                    spawn6.SetActive(false);
                    deActivated = true;
                }
            }else{
                if(spawn4 && spawn5 && spawn6){
                    spawn4.SetActive(false);
                    spawn5.SetActive(false);
                    spawn6.SetActive(false);
                }
                if(GameObject.FindWithTag("Player") && GameObject.FindWithTag("Player").GetComponent<Character>().floor && GameObject.FindWithTag("Player").GetComponent<Character>().floor.name == "Floor3"){
                    spawn7.SetActive(true);
                    if(spawn7.GetComponent<EnemySpawn>().cantEnemies > 0){
                        spawn7.GetComponent<MeshRenderer>().enabled = true;
                        spawn7.GetComponent<EnemySpawn>().enabled = true;
                    }else if(!GameObject.FindWithTag("Enemy")){
                        spawn7.GetComponent<MeshRenderer>().enabled = false;
                        spawn7.GetComponent<EnemySpawn>().enabled = false;
                        spawn7.SetActive(false);
                    }
                }else{
                    if(spawn7){
                        spawn7.SetActive(false);
                    }

                }
            }
        }


        return;
    }
}
