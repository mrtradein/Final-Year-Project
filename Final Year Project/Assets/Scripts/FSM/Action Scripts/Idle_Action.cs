using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Idle")]
public class Idle_Action : Action
{
    public override void Act(StateController controller)
    {
        IdleAction(controller);
    }

    private void IdleAction(StateController controller)
    {
        Debug.Log("Idle Action");
        //controller.state_enum
        controller.GetComponent<Animator>().SetBool("Bored", false);
        //controller.GetComponent<Animator>().SetBool("Bored", false);
    }
}