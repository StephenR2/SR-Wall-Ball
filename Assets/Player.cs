/* Stephen Randall
 * 03/16/18
 * This script is responsible for position of paddle, speed of paddle, etc.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
	public float paddleSpeed = .25f; // Sets paddle move speed
	private float dist;
	private bool dragging = false;
	private Vector3 offset;
	private Transform toDrag;
	private Vector3 playerPos;
	private float zPos = -9.5f;

	void Start () {
		transform.position = new Vector3 (0, 1, -9.5f); //Position of the paddle upon spawning


	}
	// Update is called
	void Update () {
		//float xPos = transform.position.x;//+ (Input.GetAxis ("Horizontal") * paddleSpeed); //Gets input from keys "LEFT", "RIGHT", "A", and "D", moves paddle accordingly
		//float yPos = transform.position.y; //+ (Input.GetAxis ("Vertical") * paddleSpeed); //Gets input from keys "UP", "DOWN", "W", and "S", moves paddle accordingly
		//playerPos = new Vector3 (Mathf.Clamp(transform.position.x, -5f, 5f),Mathf.Clamp(transform.position.y,1f, 7.5f),-9.5f); //Sets barriers for the x,y and z direction. so paddle stays in play.
		///	if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
		//		Vector3 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
		//		transform.Translate (-touchDeltaPosition.x * paddleSpeed, -touchDeltaPosition.y * paddleSpeed, 0);
		//	}
		//	transform.position = playerPos; // Set paddle to follow keys.
		Vector3 v3;

		if (Input.touchCount != 1) {
			dragging = false; 
			return;
		}

		Touch touch = Input.touches [0];
		Vector3 pos = touch.position;

		if (touch.phase == TouchPhase.Began) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (pos); 
			if (Physics.Raycast (ray, out hit) && (hit.collider.tag == "Player")) {
				Debug.Log ("Here");
				toDrag = hit.transform;
				dist = hit.transform.position.z - Camera.main.transform.position.z;
				v3 = new Vector3 (pos.x, pos.y, dist);
				playerPos = new Vector3 (Mathf.Clamp(pos.x, -5f, 5f),Mathf.Clamp(pos.y,1f, 7.5f), dist);
				v3 = Camera.main.ScreenToWorldPoint (v3);
				offset = toDrag.position - v3;
				dragging = true;
			}
		}
		if (dragging && touch.phase == TouchPhase.Moved) {
			v3 = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, dist);
			v3 = Camera.main.ScreenToWorldPoint (v3);
			toDrag.position = v3 + offset;
		}
		if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
			dragging = false;
		








		}
	}
}
