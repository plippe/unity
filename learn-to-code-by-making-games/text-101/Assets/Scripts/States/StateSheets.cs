using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSheets : State
{
    public override string Text()
    {
        return "You can't believe you sleep in these things. Surely it's " +
            "time somebody changed them. The pleasures of prison life " +
            "I guess!\n\n" +
            "Press R to Return to roaming your cell";
    }

    public override Dictionary<KeyCode, State> Actions()
    {
        return new Dictionary<KeyCode, State>()
        {
            {KeyCode.R, new StateCell()}
        };
    }
}