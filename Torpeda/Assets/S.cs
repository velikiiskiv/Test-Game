using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}
	public void Load1() {
		SceneManager.LoadScene("Torpeda");
	}
	public void Quit1() {
		Application.Quit();
	}
}
