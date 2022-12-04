using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{   
    public GameObject pauseUI, winUI, loseUI;
    public int lifeCounter = 3;
    public TextMeshProUGUI lifes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifes.text = lifeCounter.ToString();
        pause();
        lose();
        win();
    }

    void pause(){
        if(Input.GetKeyDown(KeyCode.Escape) && !GameObject.FindWithTag("Player").GetComponent<Animator>().GetBool("Win")){
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }else if(GameObject.FindWithTag("Player") && GameObject.FindWithTag("Player").GetComponent<Animator>().GetBool("Win")){
            Time.timeScale = 1;
            pauseUI.SetActive(false);
        }
        return;
    }

    public void resume(){
        Time.timeScale = 1;
    }

    public void quit(){
        Time.timeScale = 1;
        if(winUI){
            winUI.SetActive(false);
        }
        if(loseUI){
            loseUI.SetActive(false);
        }
        SceneManager.LoadScene(0);
    }

    void win(){
        if(GameObject.FindWithTag("Win").transform.childCount > 0 && GameObject.FindWithTag("Win").transform.GetChild(0).tag == "Player"){
            winUI.SetActive(true);
        }
        return;
    }

    void lose(){
        if(lifeCounter <=0){
            loseUI.SetActive(true);
            if(GameObject.FindWithTag("Player")){
                GameObject.FindWithTag("Player").GetComponent<Character>().enabled = false;
                if(GameObject.Find("CM FreeLook1")){
                    GameObject.Find("CM FreeLook1").SetActive(false);
                }
            }
        }
        return;
    }
}
