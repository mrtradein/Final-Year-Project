using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HeardNoise")]
public class HeardNoise_Decision : Decision
{

    public override bool Decide(StateController controller)
    {
        bool i = NoiseCheck(controller);
        return i;
    }

    private bool NoiseCheck(StateController controller)
    {
        if (controller.heard_bool == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}