using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartZone : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider col){
		if (col.GetComponent<Collider>().tag == "Ball") {
			SceneManager.LoadScene ("SchoolYard");

		}
	}
}
