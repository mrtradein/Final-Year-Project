using UnityEngine;
using System.Collections;

public class AutoIntensity : MonoBehaviour
{

    public StateController stateController;
    public GameObject AI_Character;

    public Gradient nightDayColor;

    public float maxIntensity = 3f;
    public float minIntensity = 0f;
    public float minPoint = -0.2f;

    public float maxAmbient = 1f;
    public float minAmbient = 0f;
    public float minAmbientPoint = -0.2f;


    public Gradient nightDayFogColor;
    public AnimationCurve fogDensityCurve;
    public float fogScale = 1f;

    public float dayAtmosphereThickness = 0.4f;
    public float nightAtmosphereThickness = 0.87f;

    public float daySpeed = 1.0f;
    public float nightSpeed = 1.0f;

    public Vector3 dayRotateSpeed;
    public Vector3 nightRotateSpeed;

    float skySpeed = 1;


    Light mainLight;
    Skybox sky;
    Material skyMat;

    void Start()
    {
        AI_Character = GameObject.Find("AI Character");
        stateController = AI_Character.GetComponent<StateController>();

        dayRotateSpeed = new Vector3(daySpeed, 0.0f, 0.0f);
        nightRotateSpeed = new Vector3(nightSpeed, 0.0f, 0.0f);

        mainLight = GetComponent<Light>();
        skyMat = RenderSettings.skybox;

    }

    void Update()
    {

        float tRange = 1 - minPoint;
        float dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minPoint) / tRange);
        float i = ((maxIntensity - minIntensity) * dot) + minIntensity;

        mainLight.intensity = i;

        tRange = 1 - minAmbientPoint;
        dot = Mathf.Clamp01((Vector3.Dot(mainLight.transform.forward, Vector3.down) - minAmbientPoint) / tRange);
        i = ((maxAmbient - minAmbient) * dot) + minAmbient;
        RenderSettings.ambientIntensity = i;

        mainLight.color = nightDayColor.Evaluate(dot);
        RenderSettings.ambientLight = mainLight.color;

        RenderSettings.fogColor = nightDayFogColor.Evaluate(dot);
        RenderSettings.fogDensity = fogDensityCurve.Evaluate(dot) * fogScale;

        i = ((dayAtmosphereThickness - nightAtmosphereThickness) * dot) + nightAtmosphereThickness;
        skyMat.SetFloat("_AtmosphereThickness", i);

        if (dot > 0)
            transform.Rotate(dayRotateSpeed * Time.deltaTime * skySpeed);
        else
            transform.Rotate(nightRotateSpeed * Time.deltaTime * skySpeed);

        if (Input.GetKeyDown(KeyCode.Alpha1)) skySpeed *= 0.5f;
        if (Input.GetKeyDown(KeyCode.Alpha2)) skySpeed *= 2f;

        if(this.transform.rotation.x >= 60.0f)
        {
            stateController.time_of_date_int = 1;
            Debug.Log("Night");
        }
        else
        {
            stateController.time_of_date_int = 0;
            Debug.Log("Day");

        }
    }
}
