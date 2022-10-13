using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{   
    float speed, lookSpeed, jumpHeight, ver, hor;
    Rigidbody rb;
    Animator anim;  
    Vector3 movePj;
    bool grounded = false;
    Vector3 actualPosition;
    Vector3 lastPosition;
    Quaternion characterRotation;
    

    // Start is called before the first frame update
    void Start()
    {   
        actualPosition = gameObject.transform.position;
        lastPosition = actualPosition;
        speed = 5f;
        lookSpeed = 2f;
        jumpHeight = 5f;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        movePlayerRelativeToCamera();
        isWalking();
        isRunning();
        jump();
    }

    void OnCollisionStay(Collision player) {
        if(player.transform.gameObject.tag == "Floor"){
            grounded = true;
        }    
    }

    void OnCollisionExit(Collision player){
        if(player.transform.gameObject.tag == "Floor"){
            grounded = false;
        }
    }

    void movePlayerRelativeToCamera(){
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");
        actualPosition = gameObject.transform.position;

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
                

        forward.y = 0f;
        right.y = 0f;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelativeVerticalInput;
        Vector3 rightRelativeHorizontalInput;

        if(!Input.GetKey(KeyCode.LeftShift)){
            speed = 5f;
            forwardRelativeVerticalInput = playerVerticalInput * forward * Time.deltaTime * speed;
            rightRelativeHorizontalInput = playerHorizontalInput * right * Time.deltaTime * speed;
        }else{
            speed = 10f;
            forwardRelativeVerticalInput = playerVerticalInput * forward * speed * Time.deltaTime;
            rightRelativeHorizontalInput = playerHorizontalInput * right * speed * Time.deltaTime;
        }

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;

        if(actualPosition != lastPosition){
            characterRotation.x = 0f;
            characterRotation.z = 0f;
            characterRotation = characterRotation.normalized;
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)){
                transform.forward = Vector3.Lerp(cameraRelativeMovement, transform.forward, Time.deltaTime);
                //transform.rotation = transform.rotation;
                Quaternion newRotation = Quaternion.LookRotation(transform.position - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, lookSpeed * Time.deltaTime);
            }
        }

        this.transform.Translate(cameraRelativeMovement, Space.World);
        
        return;
    }

    void isWalking(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)){
            anim.SetBool("IsWalking", true);
        }else{
            anim.SetBool("IsWalking", false);
        }
        return;
    }

    void isRunning(){
        if(Input.GetKey(KeyCode.LeftShift)){
            anim.SetBool("IsRunning",true);
        }else if(Input.GetKeyUp(KeyCode.LeftShift)){
            anim.SetBool("IsRunning",false);
        }
    }

    void jump(){
        if((Input.GetKeyDown(KeyCode.Space) && grounded) || Input.GetKeyDown(KeyCode.Space) && grounded){
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            anim.SetBool("Jump",true);
        }else if(!grounded){
            anim.SetBool("Jump",false);
        }
        return;
    }
}
