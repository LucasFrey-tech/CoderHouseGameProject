using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletV2 : MonoBehaviour
{   
    
    public int speed;
    public Vector3 direction;
    public int damage;
    public float timeDestroy;

    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        Destroy(gameObject,timeDestroy);
    }
}
