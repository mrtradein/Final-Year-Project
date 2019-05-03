using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Light Switch")]
public class LightSwitch_Decision : Decision

{
    public override bool Decide(StateController controller)
    {
        bool ans = timer(controller);
        return ans;
    }




    public bool timer(StateController controller)
    {
        if (controller.time_of_date_int == 0 && controller.lightSwitch.GetComponent<Animator>().GetBool("Switch") == true 
            || controller.time_of_date_int == 1 && controller.lightSwitch.GetComponent<Animator>().GetBool("Switch") == false)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


}