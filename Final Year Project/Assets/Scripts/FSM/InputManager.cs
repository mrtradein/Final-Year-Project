using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public GameObject playerHUD;
    
    public GameObject AIScript_GameObject;

    public GameObject AICharacter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardInput();


    }

    private void KeyboardInput()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            playerHUD.SetActive(true);
        }
        else
        {
            playerHUD.SetActive(false);
        }
    }
}
