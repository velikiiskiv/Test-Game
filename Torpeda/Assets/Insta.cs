using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Insta : MonoBehaviour {

	public int i;
	public int k;
	public GameObject Plane;
	public GameObject Plan;
	public GameObject Boss;
	public GameObject Bos;
	public float speed;
	public Vector3 pos;
	public GameObject Pushka;
	bool good;

	void Start () {
		good = true;
		Invoke ("Inst", 2.0f);
		}

	void Update () {
		
		if (Pushka == null) {
			Invoke ("Vremya", 2.0f);
		}
		if (good == false && Boss == null) {
			Invoke ("Vremya", 2.0f);
		}
	}

	void Inst() {
		if (i < 15) {
			Plane = Instantiate (Plan, new Vector2 (-10.0f, Random.Range (1.5f, 4.0f)), Quaternion.Euler(0, transform.rotation.eulerAngles.y - 180f, 0));
			Plane.GetComponent<AudioSource> ().Play ();
			i++;
			Invoke ("Inst1", 1.5f);
		}
	}
		void Inst1() {
		if (k < 15) {
			Plane = Instantiate (Plan, new Vector2 (10.0f, Random.Range (1.5f, 4.0f)), Quaternion.identity);
			Plane.GetComponent<AudioSource> ().Play ();
			k++;
			Invoke ("Inst", 1.5f);
		}
		if (k == 15) {
			Invoke ("InstBoss", 5.0f);
		}
	}
	void Vremya(){
		SceneManager.LoadScene("GameOver");
	}
	void InstBoss() {
		good = false;
			Boss = Instantiate (Bos, new Vector2 (10.0f, Random.Range (3.0f, 4.0f)), Quaternion.identity);
		Boss.GetComponent<AudioSource> ().Play ();
	}
}
