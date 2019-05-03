using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson {

    public class AI_Script : MonoBehaviour
    {

        public bool moveTowardsDestination;

        //public AnimatorController AC;
        //public GameObject AC_obj;

        StateController SC;
        public GameObject SC_obj;

        public Transform destination;
        
        public Transform lightSwitch_Transform;

        public GameObject Position1;
        public GameObject Position2;
        public GameObject Position3;

        public bool sit_bool;
        public Transform sit_target;

        public UnityEngine.AI.NavMeshAgent agent { get; private set; }// the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for


        private void Start()
        {
            moveTowardsDestination = false;
            //AC_obj = this.gameObject;
            //AC = AC_obj.GetComponent<AnimatorController>();

            SC_obj = this.gameObject;
            SC = SC_obj.GetComponent<StateController>();

            destination = Position1.transform;

            // testing
            sit_bool = false;


            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }


        private void Update()
        {
            //another test
            //this.GetComponent<Animator>().MatchTarget(destination.transform.position, destination.rotation, AvatarTarget.Body,
                                                       //new MatchTargetWeightMask(Vector3.one, 1f), 0.141f, 0.78f);

            destination = SC.destination;
            SetTarget(destination);

            //Move AI Character to target position
            if (moveTowardsDestination == true)
            {
                MoveToTarget();
            }

            // Call Keyboard Input every frame
            KeyboardInput();

            
            //Set_Sit_Animation();

            float dist = Vector3.Distance(target.transform.position, this.transform.position);
            if (dist <= 1.0f)
            {
                moveTowardsDestination = false;

                if (this.GetComponent<StateController>().Happiness_f >= 70.0f)
                {
                    this.GetComponent<Animator>().SetBool("Happy Walking", false);
                }
                if (this.GetComponent<StateController>().Happiness_f < 70.0f)
                {
                    this.GetComponent<Animator>().SetBool("Walking", false);
                }
                if (this.GetComponent<StateController>().Happiness_f < 40.0f)
                {
                    this.GetComponent<Animator>().SetBool("Sad Walking", false);
                }

                //AC.Walk_Animation_False();
                //Set_Idle_Animation();
            }
            else
            {
                moveTowardsDestination = true;
                //this.GetComponent<Animator>().SetBool("Walking", true);
                if (this.GetComponent<StateController>().Happiness_f >= 70.0f)
                {
                    this.GetComponent<Animator>().SetBool("Happy Walking", true);
                }
                if (this.GetComponent<StateController>().Happiness_f >= 40.0f && this.GetComponent<StateController>().Happiness_f < 70.0f)
                {
                    this.GetComponent<Animator>().SetBool("Walking", true);
                }
                
                if (this.GetComponent<StateController>().Happiness_f < 40.0f)
                {
                    this.GetComponent<Animator>().SetBool("Sad Walking", true);
                }
                //AC.Walk_Animation_True();

            }



        }

        
    


        public void SetTarget(Transform target)
        {
            this.target = target;
            //this.GetComponent<Animator>().SetBool("Walking", true);
        }

        public void KeyboardInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetTarget(Position1.transform);
                this.GetComponent<Animator>().SetBool("Walking", true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetTarget(Position2.transform);
                this.GetComponent<Animator>().SetBool("Walking", true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetTarget(Position3.transform);
                this.GetComponent<Animator>().SetBool("Walking", true);
            }
        }

        public void MoveToTarget()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }

        


        public void Set_Sit_Animation()
        {
            if (sit_bool == true)
            {
                SetTarget(Position1.transform);
                this.GetComponent<Animator>().SetBool("Walking", true);

                float dist = Vector3.Distance(Position1.transform.position, this.transform.position);
                if (dist <= 1.0f)
                {
                    this.GetComponent<Animator>().SetBool("Sit", true);
                    //this.GetComponent<Animator>().SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);


                    this.transform.position = sit_target.transform.position;
                    this.transform.rotation = sit_target.transform.rotation;
                    
                    Debug.Log("SIT");

                }
                else
                {
                    this.GetComponent<Animator>().SetBool("Sit", false);
                }
            }
        }

        public void Set_Idle_Animation()
        {
            this.GetComponent<Animator>().SetBool("Walking", false);

        }

        public void LightSwitch()
        {
                //SetTarget(lightSwitch_Transform.transform);
                //this.GetComponent<Animator>().SetBool("Walking", true);
            
        }
        public void TestSofa()
        {
            this.transform.position = Position1.transform.position;
            this.GetComponent<Animator>().MatchTarget(sit_target.transform.position, sit_target.rotation, AvatarTarget.LeftHand, new MatchTargetWeightMask(Vector3.one, 1.0f), 0.1f, 1.0f);
            Debug.Log("SofaTest");

        }
    }

    

}
