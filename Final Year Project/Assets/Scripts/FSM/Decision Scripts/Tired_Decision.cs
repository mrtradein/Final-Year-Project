using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Tired")]
public class Tired_Decision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool i = TiredCheck(controller);
        return i;
    }

    private bool TiredCheck(StateController controller)
    {
        if (controller.Enegry_f <= 10.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}