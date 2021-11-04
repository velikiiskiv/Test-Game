using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

	public Vector3 pos;
	public float speed;
	public float edge;
	public float chance;
	public float bottom;
	public GameObject Bomb;
	public GameObject Bomba;
	float y;

	void Start () {
		
		Invoke("Drop", Random.Range (1.0f, 1.5f));
	}

	void Update () {
		if (transform.position.x == 10.0f) {
			speed *= -1;
		}
		pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		if (transform.position.x == -10.5f) {
			speed *= -1;
		}
			
		if (transform.position.x < -edge) {
			Destroy(gameObject);
		} else if (transform.position.x > edge) {
			Destroy(gameObject);
		} 
		if (Random.value < chance && transform.position.x > -5 && transform.position.x < 5) {
			transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 180f, 0);
			speed *= -1;
		}
		if (Bomba.transform.position.y < bottom) {
			Destroy (Bomba);
		}
			}

	void Drop() {

		Bomba = Instantiate<GameObject>(Bomb);
		Bomba.transform.position = transform.position;
		Bomba.transform.position = Bomba.transform.position + new Vector3 (0, -0.2f, 0);
		Invoke("Drop", Random.Range (1.0f, 1.5f));
	}


}
