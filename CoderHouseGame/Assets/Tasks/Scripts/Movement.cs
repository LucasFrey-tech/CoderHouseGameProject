using UnityEngine;

public class Movement : MonoBehaviour
{
    public int velocity = 2;
    public GameObject firstCam;
    public GameObject secondCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        cameras();
    }

    void move(){
        if(Input.GetKey(KeyCode.W)){
            transform.position += new Vector3(0f,0f,1f) * Time.deltaTime * velocity;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position += new Vector3(0f,0f,-1f) * Time.deltaTime * velocity;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(1f,0f,0f) * Time.deltaTime * velocity;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position += new Vector3(-1f,0f,0f) * Time.deltaTime * velocity;
        }
        return;
    }

    void cameras(){
        if(Input.GetKeyDown(KeyCode.C)){
            if(firstCam.activeSelf){
                secondCam.SetActive(true);
                firstCam.SetActive(false);
            }else{
                firstCam.SetActive(true);
                secondCam.SetActive(false);
            }
        }
        return;
    }
}

