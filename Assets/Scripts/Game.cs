using UnityEngine;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{   
    public GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pause();
    }

    void pause(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }
        return;
    }

    public void resume(){
        Time.timeScale = 1;
    }

    public void quit(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
