using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Bored")]
public class Bored_Decision : Decision
{
    public bool temp;
    public float t;

    public override bool Decide(StateController controller)
    {
        bool ans = timer(controller);
        return ans;
    }

    
    

    public bool timer(StateController controller) {
        t -= Time.deltaTime;
        if (t <= 0.0f)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    
}