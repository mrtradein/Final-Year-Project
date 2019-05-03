using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/WalkAbout")]
public class WalkAbout_Decsision : Decision
{
   

    public override bool Decide(StateController controller)
    {
        
        bool walkAbout = WalkAbout(controller);
        return walkAbout;
    }

    public bool WalkAbout(StateController controller)
    {
        float dist = Vector3.Distance(controller.destination.transform.position, controller.transform.position);
        if(controller.collision_bool == true) { 
            return true;
        }
        else
        {
            return false;
        }
    }
       
}