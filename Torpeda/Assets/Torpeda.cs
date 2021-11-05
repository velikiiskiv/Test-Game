﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Torpeda : MonoBehaviour {

	public GameObject Exp;
	public GameObject Boom;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Plane") {
			Boom = Instantiate (Exp, new Vector2 (transform.position.x, transform.position.y + 0.3f), Quaternion.identity);
			Boom.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}

}
