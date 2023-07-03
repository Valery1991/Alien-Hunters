using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Deze class heb ik aangemaakt zodat de speler niet meteen in het spel 'gegooid' wordt bij het openen van de .exe file, maar zodat er een duidelijk menu is. 

public class MainMenu : MonoBehaviour {

	public string firstLevel;

	public GameObject continueButton;

	void Start()
	{
		if(PlayerPrefs.HasKey("FurthestLevelReached"))
		{
			continueButton.SetActive(true);
		}
	}

	public void StartGame()
	{
		SceneManager.LoadScene(firstLevel);

		PlayerPrefs.SetInt("CurrentLives", 3);
		PlayerPrefs.SetInt("CurrentScore", 0);

		if(!PlayerPrefs.HasKey("HiScore"))
		{
			PlayerPrefs.SetInt("HiScore", 0);
		}
	}

    // Het is ook mogelijk om via het pauze menu terug te keren naar dit scherm, zodat het spel herstart kan worden zonder dat de speler het daadwerkelijk af hoeft te sluiten.
    // Natuurlijk kan de speler ook de applicatie compleet afsluiten vanuit dit menu.

    public void QuitGame()
	{
		Application.Quit();
	}

    // Indien er meerder levels aanwezig zouden zijn, zou de speler ook 'continue game' vanuit dit scherm kunnen selecteren zodat zij verder kunnen waar zij gebleven zijn.

    public void ContinueGame()
	{
		PlayerPrefs.SetInt("CurrentLives", 3);
		PlayerPrefs.SetInt("CurrentScore", 0);

		if(!PlayerPrefs.HasKey("HiScore"))
		{
			PlayerPrefs.SetInt("HiScore", 0);
		}

		SceneManager.LoadScene(PlayerPrefs.GetString("FurthestLevelReached"));
	}
}