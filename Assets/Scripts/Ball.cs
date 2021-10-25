using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public Slider slider;
	public bool n;
	[Range(1f, 25f)]
	public float speed;
	public float speedes = 45f;
	public Vector3 kiiforce;
	public Rigidbody rb;
	public float a;
	public float b;
	private float x = 0.68f;
	private float z = - 0.05f;
	public GameObject ball;
	public GameObject kii;
	public GameObject bit;
	public GameObject piv;
	private float d = 0.09f;
	private int cools = 4;
	private int count = 2;

	void Start() 
	{
		ball = GameObject.Find ("Shar");
		for (int i = 0; i < cools; i++) {
			for (int n = 0; n < count; n++) {
				Instantiate (ball, new Vector3 (x, 0.885f, z), Quaternion.identity);
				z += d;
			}
			x += d;
			z = z - (d * count + d / 2);
			count++;
		}
	}

	void Update() 
	{
		
		if (speedes < 40f) {
			speedes = rb.velocity.magnitude;
		}
		if (n == false) {
			Invoke ("Zhdu", 3f);
		}
	}
	public void Spee() {
		speedes = rb.velocity.magnitude;

	}
	public void Zhdu() {
		if (speedes < 0.02f) {
			kii.SetActive (true);
			n = true;
		}
	}
	public void Pusk() {
		a = bit.transform.position.x - kii.transform.position.x;
		b = bit.transform.position.z - kii.transform.position.z;
		kiiforce = new Vector3 (a, 0, b);
		rb.AddForce (kiiforce*speed, ForceMode.Impulse);
		kii.SetActive (false);
		Invoke ("Spee", 3f);
		n = false;
	}
	public void Polz() {
		
		speed = slider.value;

	}
}
