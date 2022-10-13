using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotate : MonoBehaviour
{   
    public int rotationVelocity;
    public int moveVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move(){
        if (Input.GetButton("Vertical")){
            transform.Translate(0,0, Input.GetAxis("Vertical") * Time.deltaTime * moveVelocity);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(0f, 30f * Time.deltaTime * rotationVelocity, 0f);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(0f, -30f * Time.deltaTime * rotationVelocity, 0f);
        }
        return;
    }

}
