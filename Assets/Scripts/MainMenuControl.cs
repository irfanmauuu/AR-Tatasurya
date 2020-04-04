using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuControl : MonoBehaviour
{
  int sceneIndex;

	// Use this for initialization
	void Start () {
		sceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

	// Update is called once per frame

	public void LoadNextLevel()
	{
		SceneManager.LoadScene (sceneIndex + 1);
	}



}
