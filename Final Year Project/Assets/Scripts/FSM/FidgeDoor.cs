using UnityEngine;
using System.Collections;

public class FidgeDoor : MonoBehaviour
{
    public GameObject[] lights;

    public Transform player;

    public bool hasPlayer = false;

    public AudioClip[] soundToPlay;
    private AudioSource audio;

    public int dmg;

    private bool touched = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
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
        if (hasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            bool temp = this.GetComponent<Animator>().GetBool("Open");
            temp = !temp;
            this.GetComponent<Animator>().SetBool("Open", temp);
            RandomAudio();
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

        UpdateLights();
    }

    public void UpdateLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (this.GetComponent<Animator>().GetBool("Switch") == true)
            {
                lights[i].GetComponentInChildren<Light>().intensity = 1;
            }
            else
            {
                lights[i].GetComponentInChildren<Light>().intensity = 0;
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

}