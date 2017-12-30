using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCellMirror : State
{
    public override string Text()
    {
        return "You are still in your cell, and you STILL want to escape! There are " +
            "some dirty sheets on the bed, a mark where the mirror was, " +
            "and that pesky door is still there, and firmly locked!\n\n" +
            "Press S to view Sheets, or L to view Lock";
    }

    public override Dictionary<KeyCode, State> Actions()
    {
        return new Dictionary<KeyCode, State>()
        {
            {KeyCode.S, new StateSheetsWithMirror()},
            {KeyCode.L, new StateLockWithMirror()}
        };
    }
}