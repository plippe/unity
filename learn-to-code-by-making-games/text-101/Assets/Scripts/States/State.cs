using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    abstract public string Text();
    abstract public Dictionary<KeyCode, State> Actions();
}