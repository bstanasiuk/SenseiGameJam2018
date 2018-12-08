using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {

    public GameObject player0;
    public GameObject player1;
    public GameObject platformy;
    public GameObject UICanvas;
    public GameObject playmodeCanvas;
    public GameObject startingScreen;
    public AudioSource bgMusic;
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
            player0.SetActive(true);
            player1.SetActive(true);
            platformy.SetActive(true);
            UICanvas.SetActive(true);
            playmodeCanvas.SetActive(true);
            bgMusic.Play();
            startingScreen.SetActive(false);
        }
	}
}
