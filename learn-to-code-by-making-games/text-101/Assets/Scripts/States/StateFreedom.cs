using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFreedom : State
{
    public override string Text()
    {
        return "You are FREE!\n\n" +
            "Press P to Play again";
    }

    public override Dictionary<KeyCode, State> Actions()
    {
        return new Dictionary<KeyCode, State>()
        {
            {KeyCode.P, new StateCell()}
        };
    }
}