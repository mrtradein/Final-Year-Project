using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Bored")]
public class Bored_Action : Action
{
    public override void Act(StateController controller)
    {
        BoredAction(controller);
    }

    private void BoredAction(StateController controller)
    {
        Debug.Log("Bored Action");
        controller.GetComponent<Animator>().SetBool("Bored", true);
    }
}