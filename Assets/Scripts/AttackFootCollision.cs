using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFootCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider foot){
        if(foot.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)){
            enemyComponent.health -= GameObject.FindWithTag("Player").GetComponent<Character>().hitDamage * 2;
            enemyComponent.GetComponent<Rigidbody>().AddForce(enemyComponent.transform.forward * -15, ForceMode.Impulse);
        }
    }
}
