using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
    
    public Transform centerMass;
    public Transform revealingLight;

    public float rotationAroundPlanetSpeed = 1.0f;
    public float rotationAroundSunDays = 1.0f;
    public float defaultEarthYear = 365.25f;
    public float satelliteOrbitDistance = 1.8f;
    public float planetSunDistance = 100.0f;
    public float planetSpeedRotation = 1.0f;

    private GlobalValues globalValuesScript;
    // Use this for initialization
    void Start () {
        globalValuesScript = Camera.main.GetComponent<GlobalValues>();

        //transform.position = (transform.position - sun.position).normalized * planetSunDistance + sun.position;
        rotationAroundPlanetSpeed = rotationAroundSunDays / defaultEarthYear;

        // For reveal light - must follow Planet and retain the same position
        if(revealingLight != null)
        {
            revealingLight.transform.LookAt(transform.position);
        }

    }
	
	// Update is called once per frame
	void Update () {
        //if (planet != null)
        //{
        //    transform.position = planet.position + (transform.position - planet.position).normalized * satelliteOrbitDistance;
        //    transform.RotateAround(planet.position, Vector3.up, rotationAroundPlanetSpeed * Time.deltaTime);
        //}

        //transform.LookAt(sun);
        //transform.Translate(Vector3.right * Time.deltaTime * (defaultEarthYear / rotationAroundSunDays) * (globalValuesScript.globalPlanetRotationAroundSun) * (rotationAroundSunDays / defaultEarthYear));



        transform.RotateAround(centerMass.position, Vector3.up, Time.deltaTime * (defaultEarthYear / rotationAroundSunDays) * (globalValuesScript.globalPlanetRotationAroundSun) * Time.deltaTime);

        transform.Rotate(-Vector3.up * Time.deltaTime * planetSpeedRotation * globalValuesScript.globalPlanetRotationAroundSun);
    }
    
}
