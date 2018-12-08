using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreen : MonoBehaviour {
	
	void Update () 
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("PlayMode", LoadSceneMode.Single);
		}
	}
}
