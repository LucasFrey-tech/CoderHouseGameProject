using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFistCollision : MonoBehaviour
{   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider fist){
        if(fist.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)){
            enemyComponent.health -= GameObject.FindWithTag("Player").GetComponent<Character>().hitDamage;
            enemyComponent.GetComponent<Rigidbody>().AddForce(enemyComponent.transform.forward * -10, ForceMode.Impulse);
        }
    }

}
