using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/WalkAbout")]
public class WalkAbout_Action : Action
{
    //public bool getNewRandomPosition = false;
    //Vector3 finalPosition = new Vector3(0.0f,0.0f,0.0f);
    StateController controller;


    public override void Act(StateController controller)
    {
        WalkAbout(controller);
    }

    private void WalkAbout(StateController controller)
    {
        Debug.Log("Walkabout Action");
        controller.walkAbout_bool = true;
        //controller.GetComponent<Animator>().SetBool("Lay Down", false);
        if (controller.Happiness_f >= 70.0f)
        {
            controller.GetComponent<Animator>().SetBool("Happy Walking", true);
            controller.GetComponent<Animator>().SetBool("Walking", false);
            controller.GetComponent<Animator>().SetBool("Sad Walking", false);

        }
        if (controller.Happiness_f >= 40.0f && controller.Happiness_f < 70.0f)
        {
            controller.GetComponent<Animator>().SetBool("Happy Walking", false);
            controller.GetComponent<Animator>().SetBool("Walking", true);
            controller.GetComponent<Animator>().SetBool("Sad Walking", false);

        }
        if (controller.Happiness_f < 40.0f)
        {
            controller.GetComponent<Animator>().SetBool("Happy Walking", false);
            controller.GetComponent<Animator>().SetBool("Walking", false);
            controller.GetComponent<Animator>().SetBool("Sad Walking", true);
        }

        //OnEnable();
        //OnDisable();


    }

    

    

   


}