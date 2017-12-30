using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    Text text;
    State state;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        state = new StateCell();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = state.Text();
        foreach (KeyValuePair<KeyCode, State> action in state.Actions())
        {
            if (Input.GetKeyDown(action.Key)) { 
                state = action.Value; 
            }
        }
    }
}