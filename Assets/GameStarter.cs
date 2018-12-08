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
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")||Input.GetButtonDown("Fire1_2")) {
            player0.SetActive(true);
            player1.SetActive(true);
            platformy.SetActive(true);
            UICanvas.SetActive(true);
            playmodeCanvas.SetActive(true);
            startingScreen.SetActive(false);
        }
	}
}
