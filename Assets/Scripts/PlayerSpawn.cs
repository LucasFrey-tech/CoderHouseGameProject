using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerSpawn : MonoBehaviour
{   
    public GameObject playerPrefab, floor, currentPlayer; 
    GameObject cam;
    // Start is called before the first frame update
    void Start(){
        cam = GameObject.Find("CM FreeLook1");
    }

    // Update is called once per frame
    void Update(){
        isExist();
        cameraObjective();
    }

    void OnCollisionExit(Collision floor){
        if(floor.transform.gameObject.tag == "Player"){
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        return;
    }

    void spawnPlayer(){
        currentPlayer = Instantiate(playerPrefab);
        currentPlayer.GetComponent<Character>().anim.SetBool("Win", false);
        currentPlayer.transform.position = gameObject.transform.position;
        return;
    }

    void isExist(){
        if(!GameObject.FindWithTag("Player")){
            if(!gameObject.GetComponent<MeshRenderer>().enabled && !gameObject.GetComponent<BoxCollider>().enabled){
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;;
            }
            spawnPlayer();
        }
        return;
    }
    
    void cameraObjective(){
        if(!cam.GetComponent<CinemachineFreeLook>().m_Follow){
            cam.GetComponent<CinemachineFreeLook>().m_Follow = currentPlayer.transform;
            cam.GetComponent<CinemachineFreeLook>().m_LookAt = currentPlayer.transform.GetChild(2).transform;
        }
        return;
    }
    
}
