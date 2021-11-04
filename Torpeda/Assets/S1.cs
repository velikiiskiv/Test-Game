using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Load2() {
		SceneManager.LoadScene("Torpeda");

	}
	public void Quit2() {
		Application.Quit();
	}
}
