using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstSceneName;

    public void OnStartClick()
    {
        Debug.Log("Starting Game");
        SceneManager.LoadScene(firstSceneName);
    }

    public void OnQuitClick()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}