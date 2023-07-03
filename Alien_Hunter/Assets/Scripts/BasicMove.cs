using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basic move is de class die gebruikt wordt voor alle movement behaviour van de assets in het spel.  Je kunt hier zien dat ik twee variables maak, 1 voor de horizontale en 1 voor verticale beweging.
public class BasicMove : MonoBehaviour {

	public float moveSpeedX;
	public float moveSpeedY;

	private Rigidbody2D theRB;

	public float rotateSpeed;

	void Start () {
		theRB = GetComponent<Rigidbody2D>();
	}

    // Vervolgens wordt bepaald hoe er omgegaan wordt met rotatie en hoe snel dit gedaan wordt.
	void Update () {
		theRB.velocity = new Vector2(moveSpeedX, moveSpeedY);

		transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (Random.Range(rotateSpeed / 2f, rotateSpeed) * Time.deltaTime));
	}

    // En dit zorgt er simpelweg voor dat zodra een object of unit van het scherm af is, dat deze vernietigd wordt.
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}

}