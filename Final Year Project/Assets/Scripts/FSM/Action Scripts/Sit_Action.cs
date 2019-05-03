using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Sit")]
public class Sit_Action : Action
{
    public override void Act(StateController controller)
    {
        SitAct(controller);
    }

    

    private void SitAct(StateController controller)
    {
        controller.walkAbout_bool = false;
        Debug.Log("Sit Action");
        controller.destination.transform.position = controller.sitPosition.transform.position;

        float dist = Vector3.Distance(controller.transform.position, controller.sitPosition.transform.position);
        if (dist <= 1.0f)
        {
            //controller.transform.position = controller.bed_Target.transform.position;
            controller.transform.SetPositionAndRotation(controller.sit_Target.position, Quaternion.Euler(0.0f, 270.0f, 0.0f));
            //INCREASE BOREDOM & AND ENEGRY
            controller.Boredom_f += ((controller.BoredomDeplete_f * 2.0f) * Time.deltaTime) * controller.timeMultiplyer;
            controller.Enegry_f += ((controller.EnegryDeplete_f * 1.25f) * Time.deltaTime) * controller.timeMultiplyer;


            controller.GetComponent<Animator>().SetBool("Sit", true);
            //Set_Idle_Animation();
        }

       
        if(controller.Boredom_f >= 80.0f)
        {
            controller.currentState = controller.AI_States[3];
            controller.timer = 0.5f;
            Debug.Log("TEST"); 
        }
    }
}