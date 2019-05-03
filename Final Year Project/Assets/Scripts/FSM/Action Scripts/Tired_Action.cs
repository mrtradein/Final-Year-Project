using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Tired")]
public class Tired_Action : Action
{
    public Transform bedTarget;
    public override void Act(StateController controller)
    {
        TiredAction(controller);
    }

    private void TiredAction(StateController controller)
    {
        controller.walkAbout_bool = false;
        Debug.Log("Tired Action");
        controller.destination.transform.position = controller.bedPosition.transform.position;

        float dist = Vector3.Distance(controller.transform.position, controller.bedPosition.transform.position);
        if (dist <= 1.0f)
        {
            //controller.transform.posi tion = controller.bed_Target.transform.position;
            controller.transform.SetPositionAndRotation(controller.bed_Target.position, Quaternion.Euler(0.0f,90.0f,0.0f));

            controller.Enegry_f += ((controller.EnegryDeplete_f*2) * Time.deltaTime) * controller.timeMultiplyer;
            controller.Boredom_f += ((controller.BoredomDeplete_f * 1.0f) * Time.deltaTime) * controller.timeMultiplyer;

        
            controller.GetComponent<Animator>().SetBool("Lay Down", true);
            //Set_Idle_Animation();
        }

        if(controller.Enegry_f >= 90.0f)
        {
            controller.currentState = controller.AI_States[3];
            controller.timer = 0.5f;
        }
    }
}