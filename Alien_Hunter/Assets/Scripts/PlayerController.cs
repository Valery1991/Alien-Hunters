using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dit is het gedeelte waar ik de verschillende functies creëer die nodig zijn voor de Player spaceship, zoals de movement input en de bullets (lasers). Ook worden hier de power-ups opgeroepen.
public class PlayerController : MonoBehaviour {

	private Rigidbody2D theRB;

	public float moveSpeed;
	public Vector2 moveInput;
	public Transform topLeft;
	public Transform bottomRight;

	private Animator anim;

	public GameObject bullet;
	public Transform bulletPoint;

	public float shotDelay;
	private float shotCounter;

	public GameObject shield;

	public bool doubleShot;
	public Transform doubleShot1;
	public Transform doubleShot2;

    // Hier roep ik de Rigidbody op, wat eigenlijk een component is van de Player unit. Dit zorgt ervoor dat mijn spaceship niet alleen een sprite is maar ook daadwerkelijk herkend wordt als een asset.
	void Start () {
		theRB = GetComponent<Rigidbody2D>();

		anim = GetComponent<Animator>();
	}

    // Dit stukje code is eigenlijk voor alle input die de Player unit krijgt. Dus deze code is verantwoordelijk ervoor dat mijn spaceship reageert op zowel de Up- als Down-keys, als de Ctrl key die gebruikt wordt om lasers te schieten.
    // Ook kijkt deze code ernaar of er sprake is van een "double shot" power-up of niet, en zo ja, dan worden er 2 lasers per keer afgeschoten.
	void Update () {
		moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		theRB.velocity = moveInput * moveSpeed;

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, topLeft.position.x, bottomRight.position.x), Mathf.Clamp(transform.position.y, bottomRight.position.y, topLeft.position.y), transform.position.z);

		anim.SetFloat("Movement", moveInput.y);

		if(Input.GetButtonDown("Fire1"))
		{
			if(doubleShot)
			{
				Instantiate(bullet, doubleShot1.position, doubleShot1.rotation);
				Instantiate(bullet, doubleShot2.position, doubleShot2.rotation);
			} else {
				Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
			}

			shotCounter = shotDelay;
		}

		if(Input.GetButton("Fire1"))
		{
			shotCounter -= Time.deltaTime;

			if(shotCounter <= 0)
			{
				if(doubleShot)
				{
					Instantiate(bullet, doubleShot1.position, doubleShot1.rotation);
					Instantiate(bullet, doubleShot2.position, doubleShot2.rotation);
				} else {
					Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
				}

				shotCounter = shotDelay;
			}
		}
	}

}