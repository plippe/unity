using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        UnitySceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
