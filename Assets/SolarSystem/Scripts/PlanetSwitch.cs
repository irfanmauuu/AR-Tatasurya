using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Planet switch.
/// </summary>
public class PlanetSwitch : MonoBehaviour {
	
    GameObject MainCamera;
    
    const float optimalDistance = 2.3f;

	public GUISkin guiSkin;

	public string planetName;

	public float baseDistance = 2.5f;
	public float baseScrollSpeed = 0.1f;

	public Light SunLight;

    public Dropdown marsSatellites;
    public Dropdown jupiterSatellites;

    private RotationAroundPlanet rotationAroundPlaneScript;

    // Deprecated GUI variables - used on Unity 4

    //bool Move = false;
    //bool showMenu = true;
    //string showMenuText = "Hide";
    //float labelWidth = 150;

    // Use this for initialization
    void Start () {
		
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        // marsSatellites.onValueChanged.AddListener(delegate { ValueChangeCheck(marsSatellites); });
        rotationAroundPlaneScript = MainCamera.GetComponent<RotationAroundPlanet>();
    }

	/// <summary>
	/// Changes the satellites.
	/// </summary>
	/// <param name="planet">Planet.</param>
    public void ChangeSatellites(string planet)
    {
        switch (planet)
        {
            case "Mars":
                MainCamera.GetComponent<PlanetInfo>().LoadTextToScrollBar(marsSatellites.captionText.text);
                break;
            case "Jupiter":
                MainCamera.GetComponent<PlanetInfo>().LoadTextToScrollBar(jupiterSatellites.captionText.text);
                break;
            default:
                break;
        }
    }
    
    // Deprecated GUI - used on Unity 4
    //void OnGUI () {

    //	GUI.skin = guiSkin;

    //	if(GUI.Button(new Rect(20,Screen.height/2 + 200,100,40), showMenuText) && !Move) {
    //		if(showMenu)
    //		{
    //			showMenuText = "Show";
    //			showMenu = false;
    //		}
    //		else
    //		{
    //			showMenuText = "Hide";
    //			showMenu = true;
    //		}
    //	}
    //	if(showMenu)
    //		{
    //		GUI.Label(new Rect(Screen.width - labelWidth, 60, labelWidth, 200), planetName);


    //		if(GUI.Button(new Rect(20,60,100,40), "Mercury")) {
    //			AssignPlanetCameraCoordinates(MercuryCamera, "Mercury");
    //			}


    //		if(GUI.Button(new Rect(20,100,100,40), "Venus")) {
    //			AssignPlanetCameraCoordinates(VenusCamera, "Venus");
    //		}

    //		if(GUI.Button(new Rect(20,140,100,40), "Earth")) {
    //			AssignPlanetCameraCoordinates(EarthCamera, "Earth");
    //			Earth.GetComponent<Renderer>().enabled = true;
    //			EarthNight.GetComponent<Renderer>().enabled = false;

    //		}

    //		if(GUI.Button(new Rect(120,140,100,40), "Earth Night")) {
    //			AssignPlanetCameraCoordinates(EarthCamera, "Earth");
    //			Earth.GetComponent<Renderer>().enabled = false;
    //			EarthNight.GetComponent<Renderer>().enabled = true;
    //		}

    //		if(GUI.Button(new Rect(220,140,100,40), "Moon")) {
    //			AssignPlanetCameraCoordinates(MoonCamera, "Moon");
    //		}

    //		if(GUI.Button(new Rect(20,180,100,40), "Mars")) {
    //			AssignPlanetCameraCoordinates(MarsCamera, "Mars");
    //		}

    //		if(GUI.Button(new Rect(20,220,100,40), "Jupiter")) {
    //			AssignPlanetCameraCoordinates(JupiterCamera, "Jupiter");
    //		}

    //		if(GUI.Button(new Rect(20,260,100,40), "Saturn")) {
    //			AssignPlanetCameraCoordinates(SaturnCamera, "Saturn");

    //			//Mathf.Lerp(gameObject.transform.position.x, JupiterCamera.transform.position.x, Time.time);
    //		}

    //		if(GUI.Button(new Rect(20,300,100,40), "Uranus")) {
    //			AssignPlanetCameraCoordinates(UranusCamera, "Uranus");

    //			//Mathf.Lerp(gameObject.transform.position.x, JupiterCamera.transform.position.x, Time.time);
    //		}

    //		if(GUI.Button(new Rect(20,340,100,40), "Neptune")) {
    //			AssignPlanetCameraCoordinates(NeptunCamera, "Neptune");

    //			//Mathf.Lerp(gameObject.transform.position.x, JupiterCamera.transform.position.x, Time.time);
    //		}

    //		if(GUI.Button(new Rect(20,380,100,40), "Sun")) {
    //			AssignPlanetCameraCoordinates(SunCamera, "Sun");

    //			//Mathf.Lerp(gameObject.transform.position.x, JupiterCamera.transform.position.x, Time.time);
    //		}
    //	}
    //}


	/// <summary>
	/// Assigns the planet camera coordinates.
	/// </summary>
	/// <param name="selectedPlanetName">Selected planet name.</param>
	public void AssignPlanetCameraCoordinates (string selectedPlanetName)
	{
		planetName = selectedPlanetName;
		
        GameObject planet = GameObject.Find(selectedPlanetName);

        if (planet != null)
        {
            rotationAroundPlaneScript.target = planet.transform;

            // Multiply distance by parent planet - for satellites (otherwise we end up with very short distance and satellite might not be visible)

            rotationAroundPlaneScript.distance = baseDistance * planet.transform.localScale.x * planet.transform.parent.localScale.x;
            
           
            rotationAroundPlaneScript.MouseWheelSensitivity = baseScrollSpeed * planet.transform.localScale.x;

            // Set maximum zoom as it will be different for each planet depends on its size (default camera FOV - 60)

            rotationAroundPlaneScript.MouseZoomMin = planet.transform.localScale.x * optimalDistance;

            // Reset fov to default value

            Camera.main.fieldOfView = rotationAroundPlaneScript.fovDefault;

            // Switch off flare if sun is selected

            if (selectedPlanetName == "Sun")
            {
                SunLight.enabled = false;
            }
            else
            {
                SunLight.enabled = true;
            }
        }
       
	}

}
