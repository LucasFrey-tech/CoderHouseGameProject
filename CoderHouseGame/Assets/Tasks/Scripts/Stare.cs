using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stare : MonoBehaviour
{   
    public GameObject player;
    Quaternion lookOnPlayer;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {   
        lookOnPlayer = Quaternion.LookRotation(player.transform.position - transform.position);
        lookAtPlayer();
    }

    void lookAtPlayer(){
        transform.rotation = Quaternion.Lerp(transform.rotation, lookOnPlayer, Time.deltaTime);
        return;
    }
}
