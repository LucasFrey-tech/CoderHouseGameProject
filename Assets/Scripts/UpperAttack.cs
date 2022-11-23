using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider fists){
        if(fists.gameObject.TryGetComponent<Character>(out Character playerComponent)){
            playerComponent.health -= GameObject.FindWithTag("Enemy").GetComponent<Enemy>().hitDamage;
            playerComponent.GetComponent<Rigidbody>().AddForce(playerComponent.transform.forward * -10, ForceMode.Impulse);
        }
    }

}
