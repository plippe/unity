using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLockWithMirror : State
{
    public override string Text()
    {
        return "You carefully put the mirror through the bars, and turn it round " +
            "so you can see the lock. You can just make out fingerprints around " +
            "the buttons. You press the dirty buttons, and hear a click.\n\n" +
            "Press O to Open, or R to Return to your cell";
    }

    public override Dictionary<KeyCode, State> Actions()
    {
        return new Dictionary<KeyCode, State>()
        {
            {KeyCode.O, new StateFreedom()},
            {KeyCode.R, new StateCellMirror()}
        };
    }
}