using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// PauseScreen is voor het pauze menu: dit geeft de speler de mogelijkheid om op elk moment het spel stil te zetten, om vervolgens direct weer verder te kunnen waar zij gebleven zijn.

public class PauseScreen : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	public void ResumeGame()
	{
		gameObject.SetActive(false);
		Time.timeScale = 1f;
	}

    // Ook is er de optie om vanuit het pauze menu terug te keren naar het hoofdmenu, of zelfs de gehele applicatie af te sluiten en terug te keren naar de desktop.

	public void QuitToMain()
	{
		SceneManager.LoadScene("Main Menu");
		Time.timeScale = 1f;
	}

	public void QuitToDesktop()
	{
		Application.Quit();
		Time.timeScale = 1f;
	}

}