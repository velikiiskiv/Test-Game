using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {

	public GameObject Exp;
	public GameObject Boom;

	void Start () {
		
	}

	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Torpeda") {
			
			Boom = Instantiate (Exp, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
			Boom.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
