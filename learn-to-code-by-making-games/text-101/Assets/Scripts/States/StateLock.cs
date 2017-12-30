using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLock : State
{
    public override string Text()
    {
        return "This is one of those button locks. You have no idea what the " +
            "combination is. You wish you could somehow see where the dirty " +
            "fingerprints were, maybe that would help.\n\n" +
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