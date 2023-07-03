using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Zoals in het spel te zien is, bewegen de enemy spaceships altijd via een vast patroon. Dat patroon wordt in deze class gecreëerd. Zo zijn er weer variables voor horizontale en verticale beweging.
public class EnemyMovement : MonoBehaviour {

	public float moveSpeedX;
	public float moveSpeedY;

	private Rigidbody2D theRB;

	public float XTarget;
	public float YTarget;

	public bool moveUp;

	public int moveType; 

	void Start () {
		theRB = GetComponent<Rigidbody2D>();
	}

	void Update () {
		switch(moveType)
		{
		case 0:
			if(transform.position.x < XTarget)
			{
				theRB.velocity = new Vector2(-moveSpeedX, -moveSpeedY);
			} else {
				theRB.velocity = new Vector2(-moveSpeedX, 0f);
			}
			break;

		case 1:
			if(transform.position.x < XTarget)
			{
				theRB.velocity = new Vector2(-moveSpeedX, moveSpeedY);
			} else {
				theRB.velocity = new Vector2(-moveSpeedX, 0f);
			}
			break;

		case 2:
			if(transform.position.x < XTarget)
			{
				if(moveUp)
				{
					if(transform.position.y > YTarget)
					{
						theRB.velocity = new Vector2(-moveSpeedX, 0f);
					} else {
						theRB.velocity = new Vector2(-moveSpeedX, moveSpeedY);
					}
				} else {
					if(transform.position.y < YTarget)
					{
						theRB.velocity = new Vector2(-moveSpeedX, 0f);
					} else {
						theRB.velocity = new Vector2(-moveSpeedX, -moveSpeedY);
					}
				}
			} else {
				theRB.velocity = new Vector2(-moveSpeedX, 0f);
			}
			break;
		}

	}


	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}