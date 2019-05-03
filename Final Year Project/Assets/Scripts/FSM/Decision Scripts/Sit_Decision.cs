using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Sit")]
public class Sit_Decision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool i = SitCheck(controller);
        return i;
    }

    private bool SitCheck(StateController controller)
    {
        if (controller.Boredom_f <= 40.0f && controller.Enegry_f >= 10.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}