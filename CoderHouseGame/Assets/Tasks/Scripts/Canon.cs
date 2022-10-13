using System.Dynamic;
using System.ComponentModel;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject bala;
    int cant = 0;
    bool j = false;
    bool k = false;
    bool l = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.J)){
            InvokeRepeating("disparo",0f,1f);
            j = true;
            k = false;
            l = false;
        }

        if(Input.GetKeyDown(KeyCode.K)){
            InvokeRepeating("disparo",0f,1f);
            j = false;
            k = true;
            l = false;
        }

        if(Input.GetKeyDown(KeyCode.L)){
            InvokeRepeating("disparo",0f,1f);
            j = false;
            k = false;
            l = true;
        }
        

        //disparo();
    }

    void disparo(){        
        
        Instantiate(bala,transform.position,transform.rotation);
        cant++;
        if(j && cant == 2){
            cant = 0;
            CancelInvoke("disparo");
        }

        if(k && cant == 3){
            cant = 0;
            CancelInvoke("disparo");
        }  

        if(l && cant == 4){
            cant = 0;
            CancelInvoke("disparo");
        }  
        
        
        /*
        if(Input.GetKeyDown(KeyCode.J)){
            for(int i = 1; i < 3; i++){
                Instantiate(bala,transform.position*(i+i),transform.rotation);
            }
        }

        if(Input.GetKeyDown(KeyCode.K)){
            for(int i = 1; i < 4; i++){
                Instantiate(bala,transform.position*(i+i),transform.rotation);
            }
        }

        if(Input.GetKeyDown(KeyCode.L)){
            for(int i = 1; i < 5; i++){
                Instantiate(bala,transform.position*(i+i),transform.rotation);
            }
        }        
        */
        return;
    }
    
}
