using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/NoiseHeard")]
public class NoiseHeard_Action : Action
{


    public override void Act(StateController controller)
    {
        NoiseHeardAction(controller);

}

private void NoiseHeardAction(StateController controller)
    {
        controller.walkAbout_bool = false;
        //controller.GetComponent<Animator>().SetBool("Walking", false);
        //controller.GetComponent<Animator>().SetBool("React", true);
        //controller.destination.transform.position = controller.transform.position;
         

        //if (controller.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Reacting") && controller.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        //{
            //controller.heard_bool = false;
            //controller.GetComponent<Animator>().SetBool("React", false);
            //controller.GetComponent<Animator>().SetBool("Walking", true);

            Debug.Log("NoiseHeard Action");
            //controller.currentState = controller.AI_States[3];
            controller.destination.transform.position = controller.heard_gameObj.transform.position;
        //}
        

        //controller.GetComponent<Animator>().SetBool("Walking", false);
        //controller.GetComponent<Animator>().SetBool("Running", true);

        

        float dist = Vector3.Distance(controller.transform.position, controller.heard_gameObj.transform.position);
        if (dist <= 1.0f)
        {
            //Set the right and left hand target position and rotation, if one has been assigned
            controller.heard_bool = false;
            controller.currentState = controller.AI_States[3];
            controller.timer = 0.5f;
            //controller.GetComponent<Animator>().SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            //controller.GetComponent<Animator>().SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            //controller.GetComponent<Animator>().SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
            //controller.GetComponent<Animator>().SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);

        }

    }

}