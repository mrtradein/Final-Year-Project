using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Interactable")]
public class Interactable_Action : Action
{
    public bool interActionComplete = false;
    public override void Act(StateController controller)
    {
        InterAction(controller);
    }

    private void InterAction(StateController controller)
    {
        controller.destination.transform.position = controller.collided_obj.gameObject.GetComponent<ThrowObject>().originalPosition;
        for (int i = 0; i < controller.chairs.Length; i++)
        {
            controller.chairs[i].isStatic = true;
            controller.collided_obj.gameObject.isStatic = false;
            Debug.Log("YEOOO");
        }

        float dist = Vector3.Distance(controller.transform.position, controller.collided_obj.gameObject.GetComponent<ThrowObject>().originalPosition);
        if (dist <= 1.0f)
        {
            
            controller.collided_obj.gameObject.GetComponent<ThrowObject>().ThrowObject_AI();
            controller.collided_obj.gameObject.GetComponent<ThrowObject>().transform.parent = null;
            controller.rightHandPos = null;
            controller.leftHandPos = null;


            Debug.Log("At Original Pos");
            controller.currentState = controller.AI_States[3];
            controller.timer = 0.5f;
            controller.collision_bool = false;

            for (int i = 0; i < controller.chairs.Length; i++)
            {
                controller.chairs[i].isStatic = false;
            }
        }
        else
        {
            controller.collided_obj.gameObject.GetComponent<ThrowObject>().GrabObjectAI();

        }
        //controller.collided_obj.GetComponent<>
    }
}