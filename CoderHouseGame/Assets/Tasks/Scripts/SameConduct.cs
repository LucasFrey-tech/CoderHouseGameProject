using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameConduct : MonoBehaviour
{       
    
    public enum enemyConduct{
        firstEnemy,
        secondEnemy
    };

    public enemyConduct conduct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wichConduct();
    }

    void wichConduct(){
        switch(conduct){
            case enemyConduct.firstEnemy:
                GetComponent<Stare>().enabled = true;
                GetComponent<Chase>().enabled = false;
                break;
            case enemyConduct.secondEnemy:
                GetComponent<Stare>().enabled = false;
                GetComponent<Chase>().enabled = true;
                break;
            default:
                break;        
        }
        return;
    }

}
