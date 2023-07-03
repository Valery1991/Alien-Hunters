using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// De LevelComplete class zorgt ervoor dat de player naar het volgende level zou kunnen gaan indien hij/zij het voorafgaande level uitgespeeld heeft. 
// Deze class hangt nauw samen met de GameManager class omdat de statistieken uit deze class hier terugkomen en opnieuw gepresenteerd worden aan de speler. 

public class LevelComplete : MonoBehaviour {

	public float timeToLoad;

	public string nextLevel;

	public GameManager theGM;

	void Start () {
		theGM = FindObjectOfType<GameManager>();
	}

	void Update () {
		timeToLoad -= Time.deltaTime;
		if(timeToLoad <= 0)
		{
			PlayerPrefs.SetInt("HiScore", theGM.currentHiScore);
			PlayerPrefs.SetInt("CurrentScore", theGM.currentScore);
			PlayerPrefs.SetInt("CurrentLives", theGM.playerLives);

			SceneManager.LoadScene(nextLevel);
		}
	}

}