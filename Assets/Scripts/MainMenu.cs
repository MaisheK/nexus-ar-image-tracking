using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Imbas()
    {
        SceneManager.LoadScene("TrackJawi");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Keluar()
    { 
        Application.Quit();
        Debug.Log("Player has quit the app");
    }
}
