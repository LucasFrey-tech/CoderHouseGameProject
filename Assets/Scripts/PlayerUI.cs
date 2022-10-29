using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{   
    public GameObject hud;
    public GameObject player;
    public Image playerHealthBar; 
    public float playerCurrentHealth;
    public float playerMaxHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(GameObject.FindWithTag("Player")){
            player = GameObject.FindWithTag("Player");
            playerCurrentHealth = player.GetComponent<Character>().health;
            playerHealthBar.fillAmount = playerCurrentHealth / playerMaxHealth;
            active();

        }else{
            deactive();
        }


    }

    void deactive(){
        hud.SetActive(false);
        return;
    }

    void active(){
       hud.SetActive(true);
        return;
    }
}
