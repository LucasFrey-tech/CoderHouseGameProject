using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonV2 : MonoBehaviour
{
    public GameObject bullet;
    public float  shootingTime;
    public float timer;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {   
        timer = shootingTime;
        //scale = bullet.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        temp();
        scaleDoubling();
    }

    
    void shoot(){
        Instantiate(bullet,transform.position,transform.rotation);
        return;
    }

    void temp(){
        timer -= Time.deltaTime;
        if(timer <= 0){
            shoot();
            tempReset();
            //bullet.transform.localScale = scale;
        }
        return;
    }

    void tempReset(){
        timer = shootingTime;
        return;
    }

    void scaleDoubling(){
        if(Input.GetKeyDown(KeyCode.Space)){
            bullet.transform.localScale *= 2;
        }
        return;
    }

}
