using UnityEngine;
using UnityEngine.UI;
public class Character : MonoBehaviour
{   
    Rigidbody rb;
    public Animator anim;  
    BoxCollider rightFist, leftFist, rightFoot;
    float speed, jumpHeight, ver, hor;
    public float health = 100f;
    public float timer = 3f;
    int clicks = 0; 
    public float hitDamage = 10f;
    public GameObject floor = null;
    public bool onCheckPoint = false;
    public bool spawned = true;
    public bool loseLife = false;
    // Start is called before the first frame update
    void Start()
    {   
        leftFist = gameObject.transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(5).GetComponent<BoxCollider>();
        rightFist = gameObject.transform.GetChild(1).GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(5).GetComponent<BoxCollider>();
        rightFoot = gameObject.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<BoxCollider>();
        
        speed = 5f;
        jumpHeight = 5f;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
    

        if(!anim.GetBool("IsDying")){
            movePlayerRelativeToCamera();    
            isWalking();
            isRunning();
            jump();
            if(gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Jump")){
                if(GameObject.FindWithTag("EnemySpawn")){
                    floor = GameObject.FindWithTag("EnemySpawn").GetComponent<EnemySpawn>().floor;
                }
            }
            isFighting();
        }
        
        playerDeath();
    }


    void OnCollisionStay(Collision player) {
        if(player.transform.gameObject.tag == "Floor"){
            anim.SetBool("Grounded", true);
            floor = player.gameObject;
        }
    }

    void OnCollisionExit(Collision player){
        if(player.transform.gameObject.tag == "Floor"){
            anim.SetBool("Grounded", false);
            floor = null;
        }
        
    }

    void OnCollisionEnter(Collision player){
        if(player.transform.gameObject.tag == "Respawn"){
            GameObject.Find("Game").GetComponent<Game>().lifeCounter--;
            Destroy(gameObject,0.5f);
        }
        if(player.transform.gameObject.tag == "Floor"){
            floor = player.gameObject;
            if(floor.gameObject.name == "Floor"){
                GameObject.Find("SpawnControl").GetComponent<CheckPoint>().check = true;
            }
        }
    
        if(player.transform.gameObject.name == "WinSpot"){
            anim.SetBool("Win", true);
        }
    }

    void movePlayerRelativeToCamera(){
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");
        

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
            speed = 12f;
            forwardRelativeVerticalInput = playerVerticalInput * forward * speed * Time.deltaTime;
            rightRelativeHorizontalInput = playerHorizontalInput * right * speed * Time.deltaTime;
        }

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;

        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)){
            transform.forward = Vector3.Lerp(cameraRelativeMovement, transform.forward, Time.deltaTime);
        }
        
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("High Blow") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Low Blow") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RoundHouse Kick")){
            this.transform.Translate(cameraRelativeMovement, Space.World);
        }
        
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
        if((GameObject.FindWithTag("Enemy") && (floor != GameObject.FindWithTag("Enemy").GetComponent<Enemy>().floor)) || (!GameObject.FindWithTag("Enemy") && !GameObject.FindWithTag("EnemySpawn"))){
            if((Input.GetKeyDown(KeyCode.Space) && anim.GetBool("Grounded")) || Input.GetKeyDown(KeyCode.Space) && anim.GetBool("Grounded")){
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                anim.SetBool("Jump",true);
            }else if(!anim.GetBool("Grounded")){
                anim.SetBool("Jump",false);
            }
        }
        return;
    }

    void playerDeath(){
        if(health <= 0){
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Dying Backwards")){
                anim.SetBool("IsDying",true);
                if(gameObject != null){
                    if(!loseLife){
                        GameObject.Find("Game").GetComponent<Game>().lifeCounter--;
                        loseLife = true;
                    }
                    Destroy(gameObject,3.5f);
                }
            }
        }
        return;
    }

    void isFighting(){
        if(GameObject.FindWithTag("Enemy") && GameObject.FindWithTag("Enemy").GetComponent<Enemy>().objective == gameObject){
            anim.SetBool("IsFighting",true); 
            if(Input.GetMouseButtonDown(0)){
                clicks ++;
                if(clicks >= 4){
                    clicks = 1;
                }
                anim.SetInteger("Attack", clicks);

            }else{
                
                anim.SetInteger("Attack", 0);
            }   

            if(anim.GetCurrentAnimatorStateInfo(0).IsName("High Blow")){
                leftFist.enabled = true;
            }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Low Blow")){
                rightFist.enabled = true;
            }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Roundhouse Kick")){
                rightFoot.enabled = true;
            }else{
                leftFist.enabled = false;
                rightFist.enabled = false;
                rightFoot.enabled = false;
            }

        }else{
            anim.SetBool("IsFighting",false);
        }
        return;
    }

}
