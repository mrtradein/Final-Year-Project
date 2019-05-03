using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public Transform ai_grabPos;

    public GameObject soundRadius;

    public bool wasThrown;

    public Vector3 originalPosition;

    public float throwForce = 10;

    public bool hasPlayer = false;
    public bool beingCarried = false;

    public AudioClip[] soundToPlay;
    private AudioSource audio;

    public int dmg;

    private bool touched = false;

    void Start()
    {
        wasThrown = false;
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            GrabObject();
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                ThrowObject_Player();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }
    void RandomAudio()
    {
        if (audio.isPlaying)
        {
            return;
        }
        audio.clip = soundToPlay[Random.Range(0, soundToPlay.Length)];
        audio.Play();

    }
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
            RandomAudio();
            
        }
        if (this.gameObject.tag == "Smashable" && wasThrown == true)
        {
            Instantiate(soundRadius, this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void GrabObject()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = playerCam;
        beingCarried = true;
    }

    public void ThrowObject_Player()
    {
        wasThrown = true;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        beingCarried = false;
        GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
    }
    public void ThrowObject_AI()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        beingCarried = false;
        
        //GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
    }


    public void GrabObjectAI()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        //transform.parent = ai_grabPos;

        transform.SetPositionAndRotation(ai_grabPos.transform.position, Quaternion.Euler(0.0f, 180.0f, 0.0f));

        beingCarried = true;
    }
}