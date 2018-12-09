using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreen : MonoBehaviour {
    private void Awake()
    {
        PlayerPrefs.SetFloat("BlackPlayerScore", 0);
        PlayerPrefs.SetFloat("WhitePlayerScore", 0);
    }

    void Update () 
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("PlayMode", LoadSceneMode.Single);
		}
	}
}
