using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSheetsWithMirror : State
{
    public override string Text()
    {
        return "Holding a mirror in your hand doesn't make the sheets look " +
            "any better.\n\n" +
            "Press R to Return to roaming your cell";
    }

    public override Dictionary<KeyCode, State> Actions()
    {
        return new Dictionary<KeyCode, State>()
        {
            {KeyCode.R, new StateCellMirror()}
        };
    }
}