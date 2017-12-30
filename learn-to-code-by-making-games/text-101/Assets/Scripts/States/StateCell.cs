using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCell : State
{
    public override string Text()
    {
        return "You are in a prison cell, and you want to escape. There are " +
            "some dirty sheets on the bed, a mirror on the wall, and the door " +
            "is locked from the outside.\n\n" +
            "Press S to view Sheets, M to view Mirror and L to view Lock";
    }

    public override Dictionary<KeyCode, State> Actions()
    {
        return new Dictionary<KeyCode, State>()
        {
            {KeyCode.S, new StateSheets()},
            {KeyCode.M, new StateMirror()},
            {KeyCode.L, new StateLock()}
        };
    }
}