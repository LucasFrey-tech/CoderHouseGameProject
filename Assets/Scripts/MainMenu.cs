using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void play(){
        SceneManager.LoadScene(1);

        return;
    }

    public void salir(){
        Application.Quit();
        return;
    }
}
