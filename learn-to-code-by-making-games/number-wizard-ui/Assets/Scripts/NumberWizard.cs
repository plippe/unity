using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(SceneManager))]
public class NumberWizard : MonoBehaviour
{
    public Text question;
    public int max = 1000;
    public int min = 1;

    int guess;
    bool isFinalGuess = false;

    SceneManager sceneManager;

    // Use this for initialization
    void Start()
    {
        sceneManager = GetComponent<SceneManager>();
        Guess(min, max);
    }

    int Mid(int min, int max)
    {
        return (max + min) / 2;
    }

    int GuessNumber(int min, int max)
    {
        int mid = Mid(min, max);
        return Random.Range(
            Mathf.Max(min, mid - 10),
            Mathf.Min(max, mid + 10)
        );
    }

    void Guess(int min, int max)
    {
        if (min == max)
        {
            isFinalGuess = true;
            question.text = "Is your number " + min + "?";
        }
        else
        {
            guess = GuessNumber(min, max);
            question.text = "Is your number higher to " + guess + "?";
        }
    }

    public void Yes() { Answer(true); }
    public void No() { Answer(false); }
    public void Answer(bool yes)
    {
        if (isFinalGuess)
        {
            string endScene = yes ? "Win" : "Lose";
            sceneManager.LoadScene(endScene);
        }
        else
        {
            if (yes)
            {
                min = guess + 1;
            }
            else
            {
                max = guess;
            }

            Guess(min, max);
        }
    }

}