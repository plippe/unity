using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMirror : State
{
    public override string Text()
    {
        return "The dirty old mirror on the wall seems loose.\n\n" +
            "Press T to Take the mirror, or R to Return to cell";
    }

    public override Dictionary<KeyCode, State> Actions()
    {
        return new Dictionary<KeyCode, State>()
        {
            {KeyCode.T, new StateCellMirror()},
            {KeyCode.R, new StateCell()}
        };
    }
}