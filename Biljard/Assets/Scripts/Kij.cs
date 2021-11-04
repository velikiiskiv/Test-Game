using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Kij : MonoBehaviour {
	public float speeds;
	public bool m;
	private float X,Y,Z;
	public GameObject piv;

	void Start () {
		
	}
	
 
	void Update () {
		if (Input.GetMouseButton (0)) {
			Invoke ("Tim", 0.1f);
		}

		X += Input.GetAxis ("Mouse X") * speeds * Time.deltaTime;
		Y += Input.GetAxis ("Mouse Y") * speeds * Time.deltaTime;
		Otmena ();
	}
	public void Krut() {
		m = true;

	}
	public void Otmena() {
		if (m == true) {
			return;
			}
		if (Input.GetMouseButton (0)) {
			piv.transform.rotation = Quaternion.Euler (Y, X, 2);
			}

		}
	public void Tim() {
		m = false;

	}	
}
