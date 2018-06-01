/* Stephen Randall
 * 06/01/18
 * This Script is responsibile for detecting when the ball goes out of play and when to restart the game.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartZone : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider col){ //When ball collides with restart zone restart game.
		if (col.GetComponent<Collider>().tag == "Ball") {
			SceneManager.LoadScene ("SchoolYard");

		}
	}
}
