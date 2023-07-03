using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Eigenlijk zegt de naam het al: ScrollBackground.cs is er om ervoor te zorgen dat de achtergrond in het spel mee scrollt.
// Ik heb dit gedaan om wat extra immersie toe te voegen, zodat het spel minder saai wordt.

public class ScrollBackground : MonoBehaviour {

	public float scrollSpeed;
	public Renderer rend;

	void Start () {
		rend = GetComponent<Renderer>();
	}

	void Update () {
		float offset = Time.time * -scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}

}