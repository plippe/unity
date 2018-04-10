using UnityEngine;
using UnityEngine.SceneManagement;

public class BallOutOfBounds : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("MainMenu/MainMenu");

    }

}
