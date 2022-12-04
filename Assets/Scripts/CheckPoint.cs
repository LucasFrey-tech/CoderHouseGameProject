using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{   
    bool first = true;
    public bool check;
    GameObject checkPoint1,checkPoint2;
    
    // Start is called before the first frame update
    void Start()
    {
        checkPoint1 = GameObject.Find("CheckPoint");
        checkPoint2 = GameObject.Find("CheckPoint2");
    }

    // Update is called once per frame
    void Update()
    {   
        activate();

    }

    void activate(){
        if(check && first && !checkPoint2.GetComponent<MeshRenderer>().enabled && !checkPoint2.GetComponent<BoxCollider>().enabled && !checkPoint2.GetComponent<PlayerSpawn>().enabled){
            first = false;
        }else if(!first){
            if(!GameObject.Find("SecondSpawn") && !GameObject.Find("ThirdSpawn") && !GameObject.FindWithTag("Enemy") || (GameObject.FindWithTag("Enemy") && (GameObject.FindWithTag("Enemy").GetComponent<Enemy>().mySpawn.name != "SecondSpawn" && GameObject.FindWithTag("Enemy").GetComponent<Enemy>().mySpawn.name != "ThirdSpawn"))){
                checkPoint1.GetComponent<MeshRenderer>().enabled = true;
                checkPoint1.GetComponent<BoxCollider>().enabled = true;
                if(GameObject.Find("SpawnPlayer")){
                    GameObject.Find("SpawnPlayer").SetActive(false);
                }
                if(!GameObject.FindWithTag("Player")){
                    checkPoint1.GetComponent<PlayerSpawn>().enabled = true;
                }
            }
        }

        if(GameObject.Find("SpawnControl").GetComponent<ActivateSpawn>().deActivated){
            checkPoint1.SetActive(false);
            checkPoint2.SetActive(true);
            checkPoint2.GetComponent<MeshRenderer>().enabled = true;
            checkPoint2.GetComponent<BoxCollider>().enabled = true;
            checkPoint2.GetComponent<PlayerSpawn>().enabled = true;
        }else{
            checkPoint2.GetComponent<MeshRenderer>().enabled = false;
            checkPoint2.GetComponent<BoxCollider>().enabled = false;
            checkPoint2.GetComponent<PlayerSpawn>().enabled = false;
        }

        return;
    }



}
