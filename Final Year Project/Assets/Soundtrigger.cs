using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetFalse", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetFalse()
    {
        this.gameObject.SetActive(false);
    }
}
