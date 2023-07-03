using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Via deze class wordt het victory screen geladen zodra de player het level/spel uitgespeeld heeft. Ook wordt er ook nog aan de speler getoond hoeveel punten hij/zij behaald heeft.

public class VictoryScreen : MonoBehaviour {

	public Text playerScore;

	void Start () {
		playerScore.text = PlayerPrefs.GetInt("CurrentScore") + " points!";
	}

	// Vanuit dit menu kan de speler ook weer terugkeren naar het hoofdmenu.
	void Update () {
		if(Input.anyKeyDown)
		{
			SceneManager.LoadScene("Main Menu");
		}
	}

}