using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pushka : MonoBehaviour {
	
	public GameObject Exp;
	public GameObject Boom;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bomba" || other.gameObject.tag == "BossTorpeda") {
			Boom = Instantiate (Exp, new Vector2 (transform.position.x, transform.position.y), Quaternion.identity);
			Boom.GetComponent<AudioSource> ().Play ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
    

}
