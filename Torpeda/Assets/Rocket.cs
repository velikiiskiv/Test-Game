using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	public GameObject Torp;
	public GameObject Spawn;
	public float forcespeed;
	public GameObject Createdtorp;
	public Vector2 torpforce;
	public float verh;
    public Vector3 mousePosition;
	public bool zaryad;
	bool too;
	public GameObject Wheel;
	public GameObject Wheel1;
	public GameObject Wheel2;
	public GameObject Wheel3;
	private Touch touch;
	private float speed;
	public GameObject Pushka;

	void Start () {
		too = false;
		zaryad = true;
		speed = 0.004f;
	}

	void Update () {
		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);
			switch (touch.phase) {
			case TouchPhase.Moved:
				too = true;
				if (touch.deltaPosition.x < 0) {
					Wheel.transform.Rotate (0, 0, transform.rotation.z + 10);
					Wheel1.transform.Rotate (0, 0, transform.rotation.z + 10);
					Wheel2.transform.Rotate (0, 0, transform.rotation.z + 10);
					Wheel3.transform.Rotate (0, 0, transform.rotation.z + 10);
				}
				if (touch.deltaPosition.x > 0) {
					Wheel.transform.Rotate (0, 0, transform.rotation.z - 10);
					Wheel1.transform.Rotate (0, 0, transform.rotation.z - 10);
					Wheel2.transform.Rotate (0, 0, transform.rotation.z - 10);
					Wheel3.transform.Rotate (0, 0, transform.rotation.z - 10);
				}

					Pushka.transform.position = new Vector2 (transform.position.x + touch.deltaPosition.x * speed, transform.position.y);

				if (transform.position.x < -8.0f) {
					Pushka.transform.position = new Vector2 (transform.position.x - touch.deltaPosition.x * speed, transform.position.y);
				}
				if (transform.position.x > 8.0f) {
					Pushka.transform.position = new Vector2 (transform.position.x - touch.deltaPosition.x * speed, transform.position.y);
				}
				break;
			case TouchPhase.Ended:
				if (too == true) {
					too = false;
					break;
				}
				else if (zaryad == true && too == false) {
					mousePosition = Input.mousePosition;
					mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
					mousePosition.z = 0;
					var vector = mousePosition - transform.position;
					transform.up = vector;
					Spawn.GetComponent<AudioSource> ().Play ();
					Generate ();
					zaryad = false;
					Invoke ("GenForce", 0.2f);
				}
				break;
			}
				}

		if (Createdtorp.transform.position.y > verh) {
			Destroy (Createdtorp);
		}
			}
		
	void Generate() { 
		Vector3 torpposition = Spawn.transform.position;
		float x = Spawn.transform.position.x - transform.position.x;
		float y = Spawn.transform.position.y - transform.position.y;
		torpforce = new Vector2 (x, y);
		Createdtorp = Instantiate (Torp, torpposition, transform.rotation) as GameObject;
		Createdtorp.GetComponent<Rigidbody2D> ().AddForce (torpforce * forcespeed, ForceMode2D.Impulse);
		}

	void GenForce(){
		zaryad = true;
	}
}
