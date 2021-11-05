using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
	public Vector3 pos;
	public float speed;
	public float edge;
	public GameObject svet;
	private int i;
	public GameObject Ex;
	public GameObject Boo;
	public GameObject BossTorp;
	public GameObject BossTorpeda;
	public GameObject Pushka;
	public Vector2 torpforce;
	public float forcespeed;

	void Start () {
		edge = 11.0f;
		i = 0;
		Invoke("Drop", Random.Range (2.0f, 2.5f));
		Pushka = GameObject.Find("Pushka");
		Invoke ("Kra", 3.0f);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Torpeda") {
			if (i < 3) {
				svet.SetActive (true);
				Destroy (other.gameObject);
				Invoke ("Blik", 0.1f);
				i++;

			} else {
				Boo = Instantiate (Ex, new Vector2 (transform.position.x, transform.position.y + 0.3f), Quaternion.identity);
				Boo.GetComponent<AudioSource> ().Play ();
				Destroy (gameObject);
				Destroy (other.gameObject);
			}
		}
	}

	void Update () {
		pos = transform.position;
		pos.x += -speed * Time.deltaTime;
		transform.position = pos;

		if (transform.position.x < -edge) {
			transform.Rotate (0, 180, 0);
			speed *= -1;
		} else if (transform.position.x > edge) {
			transform.Rotate (0, 180, 0);
			speed *= -1;
			} 
	}
	void Blik() {
		svet.SetActive (false);
	}
	void Kra() {
		edge = 8.0f;
	}
	void Drop() {

		BossTorpeda = Instantiate<GameObject>(BossTorp);
		BossTorpeda.transform.position = transform.position;
		BossTorpeda.transform.position = BossTorpeda.transform.position + new Vector3 (0, -0.4f, 0);
		float x = Pushka.transform.position.x - BossTorpeda.transform.position.x;
		float y = Pushka.transform.position.y - BossTorpeda.transform.position.y;
		torpforce = new Vector2 (x, y);
		BossTorpeda.transform.up = - torpforce;
		BossTorpeda.GetComponent<Rigidbody2D> ().AddForce (torpforce * forcespeed, ForceMode2D.Impulse);
		Invoke("Drop", Random.Range (2.0f, 2.5f));
	}
}