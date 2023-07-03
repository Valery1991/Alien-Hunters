using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Deze class is alleen voor de Boss character in het spel, dus de eindbaas aan het einde van het level. Ik bepaal in deze code zowel de movement van de Boss, als de manier waarop hij schiet en hoeveel health hij heeft.
public class Boss1 : MonoBehaviour {

	public bool phase0;
	public bool phase1;
	public bool phase2;
	public bool phase3;
	public bool phase4;

	public float countDownToStart;

	public GameObject theBoss;
	public Transform topPosition;
	public Transform bottomPosition;
	public float moveSpeedX;
	public float moveSpeedY;

	public bool moveUp;

	public GameObject laser1;
	public GameObject laser2;

	public Transform shotPoint1;
	public Transform shotPoint2;
	public Transform shotPoint3;
	public Transform shotPoint4;

	public float shotDelay;
	private float shotCounter;

	public GameObject topLaserHand;
	public GameObject bottomLaserHand;

	public int topHandHealth;
	public int bottomHandHealth;

	public GameObject explosion;

	public int mainHealth;

	public float shotDelay2;
	private float shotCounter2;

	public static bool canBeHurt;

	public GameObject levelWinScreen;
	public float timeToLevelWin;

	void Start () {
		
	}

	void Update () {
		if(phase0)
		{
			countDownToStart -= Time.deltaTime;

			if(countDownToStart < 0)
			{
				phase1 = true;
				phase0 = false;
			}
		}

		if(phase1)
		{
			theBoss.transform.position = Vector3.MoveTowards(theBoss.transform.position, new Vector3(topPosition.position.x, theBoss.transform.position.y, theBoss.transform.position.z), moveSpeedX * Time.deltaTime);

			if(theBoss.transform.position.x == topPosition.position.x)
			{
				canBeHurt = true;
				phase1 = false;
				phase2 = true;
			}
		}

        // Dit zorgt er eigenlijk voor dat de Boss geen stationaire unit is maar ook naar boven en beneden beweegt terwijl hij schiet, zodat het gevecht wat lastiger wordt.
		if(!phase0 && !phase1)
		{
			if(!moveUp)
			{
				theBoss.transform.position = Vector3.MoveTowards(theBoss.transform.position, new Vector3(theBoss.transform.position.x, bottomPosition.transform.position.y,  theBoss.transform.position.z), moveSpeedY * Time.deltaTime);

				if(theBoss.transform.position.y <= bottomPosition.position.y)
				{
					moveUp = true;
				}
			} else {
				theBoss.transform.position = Vector3.MoveTowards(theBoss.transform.position, new Vector3(theBoss.transform.position.x, topPosition.transform.position.y,  theBoss.transform.position.z), moveSpeedY * Time.deltaTime);

				if(theBoss.transform.position.y >= topPosition.position.y)
				{
					moveUp = false;
				}

			}

			shotCounter -= Time.deltaTime;

			if(shotCounter <= 0)
			{
				Instantiate(laser1, shotPoint1.position, shotPoint1.rotation);
				Instantiate(laser1, shotPoint2.position, shotPoint2.rotation);
				shotCounter = shotDelay;
			}
		}

        // De boss bestaat uit een aantal phases, hij heeft namelijk 2 handen die eerst kapot gemaakt moeten worden voordat je aan de boss zelf kunt beginnen. 
        // Deze code zorgt ervoor dat er ook daadwerkelijk een update in het spel plaatsvindt zodra de speler genoeg schade aan de handen heeft gericht.
		if(phase2)
		{
			if(topHandHealth <= 0)
			{
				Instantiate(explosion, topLaserHand.transform.position, topLaserHand.transform.rotation);
				topLaserHand.SetActive(false);
				topHandHealth = 9999;
			}

			if(bottomHandHealth <= 0)
			{
				Instantiate(explosion, bottomLaserHand.transform.position, bottomLaserHand.transform.rotation);
				bottomLaserHand.SetActive(false);
				bottomHandHealth = 9999;
			}

			if(topHandHealth == 9999 && bottomHandHealth == 9999)
			{
				phase2 = false;
				phase3 = true;
			}
		}

        // Phase 3 wordt gestart wanneer de speler de boss naar 0 health gebracht heeft.
		if(phase3)
		{
			shotCounter2 -= Time.deltaTime;

			if(shotCounter2 <= 0)
			{
				Instantiate(laser2, shotPoint3.position, shotPoint3.rotation);
				Instantiate(laser2, shotPoint4.position, shotPoint4.rotation);
				shotCounter2 = shotDelay2;
			}


			if(mainHealth <= 0)
			{
				Instantiate(explosion, theBoss.transform.position, theBoss.transform.rotation);
				Instantiate(explosion, shotPoint1.transform.position, shotPoint1.transform.rotation);
				Instantiate(explosion, bottomLaserHand.transform.position, bottomLaserHand.transform.rotation);
				phase3 = false;
				phase4 = true;
				shotCounter = 500;
				theBoss.SetActive(false);
			}
		}

        // En phase 4 is eigenlijk om het "Victory" screen op te roepen na het verslaan van de boss. 
		if(phase4)
		{
			timeToLevelWin -= Time.deltaTime;

			if(timeToLevelWin <= 0)
			{
				levelWinScreen.SetActive(true);
				gameObject.SetActive(false);
			}
		}
	}

}