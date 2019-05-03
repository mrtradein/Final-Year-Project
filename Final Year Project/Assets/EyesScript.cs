using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesScript : MonoBehaviour
{

    public float heightMultiplyer;
    public float sightDistance;

    // Start is called before the first frame update
    void Start()
    {
        heightMultiplyer = 1.36f;
        sightDistance = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Looking();
    }

    public void Looking()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplyer, transform.forward * sightDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplyer, (transform.forward + transform.right).normalized * sightDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplyer, (transform.forward - transform.right).normalized * sightDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplyer, (transform.forward + transform.forward).normalized * sightDistance, Color.red);


        // forward
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplyer, transform.forward, out hit, sightDistance))
        {
            if(hit.collider.gameObject.tag == "something")
            {
                // do sometyhing
                // target = hit.collider.gameobject

            }
        }

        // right
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplyer, (transform.forward + transform.right).normalized, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "something")
            {
                // do sometyhing
                // target = hit.collider.gameobject

            }
        }

        // left
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplyer, (transform.forward - transform.right).normalized, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "something")
            {
                // do sometyhing
                // target = hit.collider.gameobject

            }
        }

        // down
        if (Physics.Raycast(transform.position + Vector3.up * heightMultiplyer, (transform.forward + transform.forward).normalized, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "something")
            {
                // do sometyhing
                // target = hit.collider.gameobject

            }
        }
    }
}
