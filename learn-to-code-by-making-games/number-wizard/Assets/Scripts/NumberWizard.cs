using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int StartMax = 1000;
    int StartMin = 1;

    int max;
    int min;

    int Mid(int min, int max) {
        return (max + min) / 2;
    }

    void StartGame() {
        max = StartMax;
        min = StartMin;

        print("Welcome to Number Wizard");
        print("Pick a number in your head, but don't tell me!");

        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);

        Guess(min, max);
        max += 1;
    }

    void Guess(int min, int max) {
        int mid = Mid(min, max);
        print("Is the number higher or lower to " + mid + "? (use arrows)");
    }

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = Mid(min, max);
            Guess(min, max);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = Mid(min, max);
            Guess(min, max);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            print("I won!");
            StartGame();
        }
    }
}
