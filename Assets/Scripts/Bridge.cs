using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{   
    float speed = 5f;
    GameObject player;
    Vector3 playerScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        appear();
    }

    void appear(){
        if(!GameObject.Find("FirstEnemySpawn") && gameObject.transform.position.y < 55f){
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 10, gameObject.transform.position.z), speed * Time.deltaTime);
        }
        return;
    }
    
}
