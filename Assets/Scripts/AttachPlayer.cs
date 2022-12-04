using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour
{   
    GameObject player;
    public bool bossDefeated = false;
    
    void OnTriggerEnter(Collider Object){
        if(Object.gameObject.tag == "Player"){
            player = Object.gameObject;
            if(gameObject.name == "WinSpot" && bossDefeated){
                player.GetComponent<Animator>().SetBool("Win", true);
                player.transform.position = gameObject.transform.position;
                player.transform.rotation = gameObject.transform.rotation;
                GameObject.Find("CM FreeLook1").SetActive(false);
                player.GetComponent<Character>().enabled = false;
            }
            player.transform.SetParent(transform);
        }
    }
     
    void OnTriggerExit(Collider Object){
        if(Object.gameObject.tag == "Player"){
            player = Object.gameObject;
            player.transform.SetParent(null);    
        }
    }
}
