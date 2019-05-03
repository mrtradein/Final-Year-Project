using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Interactable")]
public class Interactable_Decision : Decision
{

    public override bool Decide(StateController controller)
    {
        //bool i = OnCollisionEnter();
        //return i;

        bool i = InteractableCheck(controller);
        return i;

    }

    private bool InteractableCheck(StateController controller)
    {
        if (controller.collision_bool == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}