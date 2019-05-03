using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/LightSwitch")]
public class LightSwitch_Action : Action
{
    
    public override void Act(StateController controller)
    {
        LightSwitchAction(controller);
    }

    private void LightSwitchAction(StateController controller)
    {
        controller.walkAbout_bool = false;

        Debug.Log("LightSwitch Action");
        controller.destination.transform.position = controller.lightSwitchPosition.transform.position;

        float dist = Vector3.Distance(controller.transform.position, controller.lightSwitchPosition.transform.position);
        if (dist <= 0.5f)
        {
            //Set the right and left hand target position and rotation, if one has been assigned

            controller.transform.SetPositionAndRotation(controller.lightSwitchPosition.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            controller.GetComponent<Animator>().SetBool("Light Switch", true);

            controller.lightSwitch.GetComponent<lightSwitch>().Switch();
            controller.currentState = controller.AI_States[3];
            //controller.GetComponent<Animator>().SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            //controller.GetComponent<Animator>().SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            //controller.GetComponent<Animator>().SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
            //controller.GetComponent<Animator>().SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);

        }






    }


}