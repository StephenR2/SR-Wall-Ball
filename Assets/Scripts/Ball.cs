/* Stephen Randall
 * 03/16/18
 * This script is responsible for ball, putting ball in play, etc.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float ballInitialVelocity = 600f; // Sets balls velocity
	private Rigidbody rb; 
	private bool BallInPlay; // Flag for when the ball is in play.
	private Vector3 DirectionPoint;
	private Quaternion Rotating;
	private Vector3 oldVel; 


	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> (); // Makes it a rigidbody


	}
	IEnumerator Start(){
		Debug.Log ("Got to start");
		Vector3 Rndposition = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(4.0f, 8.5f), 0);
		yield return new WaitForSeconds (2);
		Serve (Rndposition);
	}
	void FixedUpdate (){
		oldVel = rb.velocity;
//		Debug.Log ("Enter Update");
		//if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) {
//			Debug.Log ("Touched");
			//Ray raycast = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);//Points Screen(Camera) to ray and gets the position of the touch.
			//RaycastHit raycastHit = new RaycastHit ();
			//if (Physics.Raycast (raycast, out raycastHit)) {
//				raycastHit.point = DirectionPoint;
//				transform.LookAt (raycastHit.point);
//				rb.isKinematic = false;
//				rb.AddRelativeForce (raycastHit.point * 100);
				//Serve (raycastHit.point); //Serves ball to the point that was hit.
			}

		
 
	

		

	// Update is called once per frame
		void Serve (Vector3 touchpos){
		
		//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//RaycastHit hit;
		//if (Physics.Raycast (ray, out hit)) {
			Vector3 dir = touchpos - transform.position;
			dir = dir.normalized; 
			rb.isKinematic = false;
			transform.LookAt (dir);
			rb.AddRelativeForce (dir * 875);
			//BallInPlay = true;
			//rb.AddForce(new Vector3(-ballInitialVelocity, ballInitialVelocity, 0));
			
		//}

	}
		void FollowTouch(){
		for (int i = 0; i < Input.touches.Length; i++) {
			Touch touch = Input.touches [i];
			Vector3 touchPos3D = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, Camera.main.nearClipPlane));
			Vector3 newpos = transform.position;
			newpos.x = touchPos3D.x;
		}
	}


	void OnCollisionEnter(Collision c){
		if (c.collider.tag == "Player") {
			ContactPoint cp = c.contacts[0];
			rb.velocity = Vector3.Reflect (oldVel, cp.normal);
			Debug.Log (rb.velocity);
			if (rb.velocity.z < 19.2f) {
				rb.velocity += cp.normal * 4f;

			}


		}


	}










}


	