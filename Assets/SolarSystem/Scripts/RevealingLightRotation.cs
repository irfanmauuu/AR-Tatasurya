using UnityEngine;
using System.Collections;

/// <summary>
/// Revealing light rotation. Script make sure that revealing light is always facing Earth.
/// </summary>
public class RevealingLightRotation : MonoBehaviour {

	/// <summary>
	/// The init rotation. Stop revealing light from rotating along with parent Earth object.
	/// </summary>
	Quaternion initRotation;
	// Use this for initialization
	void Start () {
		 initRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = initRotation;

	}
}
