using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Deze class kijkt hoe de interactie met de player verloopt wanneer deze geraakt wordt door de enemy. Zo controleert deze code of er een shield aanwezig is of niet.
// Verder herkent deze code ook dat zodra de player al zijn levens verliest, hij/zij dood gaat en de spaceship dus vernietigd wordt.

public class HurtPlayer : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Shield")
		{
			other.gameObject.SetActive(false);
			Destroy(gameObject);
		}

		if(other.gameObject.tag == "Player")
		{
			FindObjectOfType<GameManager>().KillPlayer();
			Destroy(gameObject);
		}


	}

}