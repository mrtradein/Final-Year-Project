using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Complete;

public class StateController : MonoBehaviour
{


    public State currentState;

    public State previousState;
    public Transform currentPosition;
    // AI Stats
    public float Happiness_f, Hunger_f, Hygiene_f, Bladder_f, Enegry_f, Boredom_f;

    // AI State Depletion Rates
    public float HappinessDeplete_f, HungerDeplete_f, HygieneDeplete_f, BladderDeplete_f, EnegryDeplete_f, BoredomDeplete_f;

    public float timeMultiplyer;

    // test to attain navigation mesh of scene
    public NavMeshSurface ground;

    // transfrom positions for target right and left hand positions
    public Transform rightHandPos;
    public Transform leftHandPos;

    // all available states  for the AI Character
    public State[] AI_States;

    //All chairs within the scene, this was an attempt to get the chairs and bake the navigation mesh in run time
    public GameObject[] chairs;

    //public Transform[] furniture_origin_position;


    //public enum state_enum 
    //{
    //    idle = 0,
    //    bored = 1,
    //    walkabout = 2,
    //}

    // if heard noise bool
    public bool heard_bool;
    // heard noise position
    public GameObject heard_gameObj;

        // if collidied with interactable object
    public bool collision_bool;
    // the gameobject that we have collided with
    public GameObject collided_obj;

    // scenes time of day integer
    public int time_of_date_int;

    // the scene enum time of day
    public enum time_of_day
    {
        day = 0,
        night = 1
    }

    public bool walkAbout_bool;
    public Vector3 new_Destination_Position;

    

    public Transform bedPosition;
    public Transform bed_Target;

    public Transform sitPosition;
    public Transform sit_Target;

    public Transform lightSwitchPosition;
    public Transform lightSwitch_Target;
    public GameObject lightSwitch;

    public Transform destination;



    //public EnemyStats enemyStats;
    public Transform eyes;
    public State remainState;
    public float timer;


    [HideInInspector] public NavMeshAgent navMeshAgent;
    //[HideInInspector] public Complete.TankShooting tankShooting;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    public bool aiActive = true;

    private void Start()
    {
        //Initalize stats
        Happiness_f = 100.0f; Hunger_f = 100.0f; Hygiene_f = 100.0f; Bladder_f = 100.0f; Enegry_f = 100.0f; Boredom_f = 100.0f;

        //Initalize stat depleting values
        //HappinessDeplete_f = 0.1f; HungerDeplete_f = 1.0f; HygieneDeplete_f = 0.5f; BladderDeplete_f = 0.4f; EnegryDeplete_f = 0.3f; BoredomDeplete_f = 0.2f;

        //Initalize stats
       

        previousState = currentState;

        collision_bool = false;
        lightSwitch = GameObject.Find("Light Switch");
        time_of_date_int = (int)time_of_day.day;

        walkAbout_bool = false;
        if(walkAbout_bool == true)
        {
            WalkAbout();
        }
        currentPosition = this.transform;
        timer = Random.Range(0.0f, 6.0f);

        for(int i = 0; i < chairs.Length; i++)
        {
            chairs[i].GetComponent<NavMeshObstacle>().enabled = false;
        }
        

    }

    void Awake()
    {
        //tankShooting = GetComponent<Complete.TankShooting>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        aiActive = true;
    }


    public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
    {
        wayPointList = wayPointsFromTankManager;
        aiActive = aiActivationFromTankManager;
        if (aiActive)
        {
            navMeshAgent.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    void Update()
    {
        DepleteStats();
        if (!aiActive)
            return;

        currentState.UpdateState(this);
        Debug.Log("Current State: " + currentState );


        // walk about 
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            if (walkAbout_bool == true)
            {
                //RandomTimer();
                WalkAbout();
                timer = 8.0f;
            }
            
        }

        //testing walkabout
        if(walkAbout_bool == true)
        {
            
        }

        Clamp();

    }

    public void DepleteStats()
    {
        Happiness_f = Mathf.Clamp(((Enegry_f + Boredom_f) / 2),0.0f,100.0f);

        Hunger_f -= (HungerDeplete_f * Time.deltaTime) * timeMultiplyer;
        Hygiene_f -= (HygieneDeplete_f * Time.deltaTime) * timeMultiplyer;
        Bladder_f -= (BladderDeplete_f * Time.deltaTime) * timeMultiplyer;

        
        Enegry_f -= (EnegryDeplete_f * Time.deltaTime) * timeMultiplyer;
        Boredom_f -= (BoredomDeplete_f * Time.deltaTime) * timeMultiplyer;

        Enegry_f =  Mathf.Clamp(Enegry_f, 0.0f, 100.0f);
        Boredom_f = Mathf.Clamp(Boredom_f, 0.0f, 100.0f);

    }

    public void RandomTimer()
    {
        timer = Random.Range(0.0f, 6.0f);
    }

    //void OnDrawGizmos()
    //{
    //    if (currentState != null && eyes != null)
    //    {
    //        //Gizmos.color = currentState.sceneGizmoColor;
    //        //Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCasdeeus);
    //    }
    //}

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Interactable")
        {
            collision_bool = true;
            collided_obj = collision.gameObject;

            if (currentState == AI_States[7])
            {
                rightHandPos = GameObject.Find(collided_obj.name + "/Handle R").transform;
                leftHandPos = GameObject.Find(collided_obj.name + "/Handle L").transform;
            }
            else
            {
                rightHandPos = null;
                leftHandPos = null;
            }
            
            //Debug.Log(AI_States[7]);
            Debug.Log("Collided with Interactable Object");
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sound")
        {
            heard_bool = true;
            heard_gameObj = other.gameObject;
            Debug.Log("Sound Heard");
        }
    }


    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

    public void WalkAbout()
    {
        //Vector3 randomDirection = Random.insideUnitSphere * 25;
        //NavMeshHit hit;
        //NavMesh.SamplePosition(randomDirection, out hit, 10, 1);


        new_Destination_Position = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));


        Debug.Log(new_Destination_Position);
        destination.transform.position = new_Destination_Position;

    }

    public void Clamp(){
        

    }
}