using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activateWall();
    }

    void activateWall(){
        if((GameObject.FindWithTag("Enemy") && (GameObject.FindWithTag("Player") && GameObject.FindWithTag("Player").GetComponent<Character>().floor == GameObject.FindWithTag("Enemy").GetComponent<Enemy>().floor)) || GameObject.FindWithTag("EnemySpawn")){
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }else{
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        return;
    }

}
