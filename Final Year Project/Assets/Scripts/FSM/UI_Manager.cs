using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    
    public class UI_Manager : MonoBehaviour
    {
        public Text Happiness_txt, Hunger_txt, Hygiene_txt, Bladder_txt ,Enegry_txt, Boredom_txt;

        public Text currentState_txt;

        public Sprite[] icons;
        public Image AI_Icon;

        public StateController stateController;
        public GameObject AI_Script_ref;

        public Image happinesesBar;
        public Image enegryBar;
        public Image boredomBar;

        // Start is called before the first frame update
        void Start()
        {
            AI_Script_ref = GameObject.Find("AI Character");
            stateController = AI_Script_ref.GetComponent<StateController>();
        }

        // Update is called once per frame
        void Update()
        {
            
            //if(stateController.currentState == stateController.AI_States[8])
            //{
                //AI_Icon.GetComponent<Image>().sprite = icons[8];
            //}
            //else
            //{
            //    AI_Icon = null;
            //}

            Happiness_txt.text = stateController.Happiness_f.ToString("0.00");
            Hunger_txt.text = stateController.Hunger_f.ToString("0.00");
            Hygiene_txt.text = stateController.Hygiene_f.ToString("0.00");
            Bladder_txt.text = stateController.Bladder_f.ToString("0.00");
            Enegry_txt.text = stateController.Enegry_f.ToString("0.00");
            Boredom_txt.text = stateController.Boredom_f.ToString("0.00");

            currentState_txt.text = stateController.currentState.ToString();

            enegryBar.GetComponent<RectTransform>().transform.localScale = new Vector3(stateController.Enegry_f/100.0f,1.0f,1.0f);
            boredomBar.GetComponent<RectTransform>().transform.localScale = new Vector3(stateController.Boredom_f / 100.0f, 1.0f, 1.0f);
            happinesesBar.GetComponent<RectTransform>().transform.localScale = new Vector3(stateController.Happiness_f / 100.0f, 1.0f, 1.0f);
        }

    }
}
