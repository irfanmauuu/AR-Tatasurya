using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Rotation around planet.
/// </summary>
public class RotationAroundPlanet : MonoBehaviour
{

    public Transform target;
    public float distance = 5f;

    // ZoomCameraMouse
    public float MouseWheelSensitivity = 1;
    public float MouseZoomMin = 1.5f;
    
    public float xSpeed = 40.0f;
    public float ySpeed = 40.0f;
    
    public float switchPlanetSmooth = 0.8f;

    private double x = 80.0f;
    private double y = 50.0f;

    public float minFov = 0.01f;
    public float maxFov = 179.9f;
    public float fovZoomSensitivity = 8.0f;
    public float fovDefault = 60.0f;
   
    Quaternion rotation;
    Vector3 position;
    
    
    public List<GameObject> planets;

    public bool isRotating;

    // Mobile

    float mobileMouseZoomSpeed = 0.5f;
    
    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;

        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
        SetPosition();
    }

    private void SetPosition()
    {
        transform.rotation = rotation;
        transform.position = rotation * new Vector3(0.0f, 0.0f, -distance) ;

        rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler((float)y, (float)x, 0), Time.deltaTime * switchPlanetSmooth);

        position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }

    void LateUpdate()
    {

        // Ignore UI Layer so we won't rotate or scroll planets on UI
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        var raycast = Physics.Raycast(ray, 500, LayerMask.NameToLayer("UI"));
        
        SetPosition();

		//Debug.Log("Raycast_" + raycast);
		//Debug.Log("Input" + Input.GetMouseButton(0));
		//Debug.Log("Rotating_" + isRotating);

        if (raycast && Input.GetMouseButton(0) || isRotating)
        {
            isRotating = true;
            x = transform.eulerAngles.y;
            y = transform.eulerAngles.x;

            x += Input.GetAxis("Mouse X") * xSpeed;
            y -= Input.GetAxis("Mouse Y") * ySpeed;
            

            // Keep rotation even if input position is out of raycast
            if (Input.GetMouseButtonUp(0))
            {
                isRotating = false;
            }

        }

        if (raycast && Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float scrollSpeed = Input.GetAxis("Mouse ScrollWheel");
            ZoomInOut(scrollSpeed);
        }

        // Mobile pinch to zoom

        MobileZoomInOut();

    }

    private void MobileZoomInOut()
    {
        if (Input.touchCount == 2)
        {
            // Get the first touch
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Calculate magnitude

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            Camera.main.fieldOfView += deltaMagnitudeDiff * mobileMouseZoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFov, maxFov);

        }
    }

    private void ZoomInOut(float scrollSpeed)
    {
        Camera.main.fieldOfView -= scrollSpeed * fovZoomSensitivity;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFov, maxFov);

    }
}
