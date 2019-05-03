using UnityEngine;
using System;
using System.Collections;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(Animator))]

    public class IKControl : MonoBehaviour
    {
        public StateController StateController;
        public GameObject StateController_obj;

        public AI_Script AI_Script;
        public GameObject AI_Character_Obj;

        protected Animator animator;

        public bool ikActive = false;

        public Transform rightHandObj = null;
        public Transform leftHandObj = null;

        public Transform lookObj = null;

        void Start()
        {
            StateController_obj = this.gameObject;
            StateController = StateController_obj.GetComponent<StateController>();

            AI_Character_Obj = GameObject.Find("AI Character");
            AI_Script = AI_Character_Obj.GetComponent<AI_Script>();
            animator = GetComponent<Animator>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Interactable")
            {
                //rightHandObj.transform.position = collision
            }

        }

        private void Update()
        {
            OnAnimatorIK();
            rightHandObj = StateController.rightHandPos;
            leftHandObj = StateController.leftHandPos;

           

        }

        //a callback for calculating IK
        void OnAnimatorIK()
        {
            if (animator)
            {

                //if the IK is active, set the position and rotation directly to the goal. 
                if (ikActive)
                {

                    // Set the look target position, if one has been assigned
                    float dist = Vector3.Distance(this.transform.position, StateController.destination.transform.position);
                    if (dist >= 2.0f)
                    {
                        animator.SetLookAtWeight(1);
                        animator.SetLookAtPosition(StateController.destination.transform.position);
                    }



                    //Set the right and left hand target position and rotation, if one has been assigned



                    if (rightHandObj != null)
                    {

                        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                        animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);

                        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                    }

                }
                //if the IK is not active, set the position and rotation of the hand and head back to the original position
                else
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetLookAtWeight(0);
                }
            }
        }
    }
}