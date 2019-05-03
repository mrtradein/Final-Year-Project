using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Idle")]
public class Idle_Decision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool i = idleCheck(controller);
        return i;
    }

    private bool idleCheck(StateController controller)
    {
        if(controller.timer <= 0.0f)
        {
            controller.RandomTimer();

            return true;
        }
        else
        {
            return false;
        }
    }
}