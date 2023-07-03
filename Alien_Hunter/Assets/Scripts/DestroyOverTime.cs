using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Deze class zorgt er simpelweg voor dat game objects die niet langer relevant zijn ook daadwerkelijk 'vernietigd' worden en niet in de game blijven bestaan. Dit om fouten en 'cluttering' te voorkomen.
public class DestroyOverTime : MonoBehaviour {

	public float lifetime;

	void Start () {
		
	}

	void Update () {
		lifetime -= Time.deltaTime;

		if(lifetime < 0)
		{
			Destroy(gameObject);
		}
	}

}