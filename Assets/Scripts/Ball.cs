/* Stephen Randall
 * 06/01/18
 * This script is responsible for ball, putting ball in play, etc.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public float ballInitialVelocity = 600f; // Sets balls velocity
	private Rigidbody rb; 
	private bool BallInPlay; // Flag for when the ball is in play.
	private Vector3 DirectionPoint;
	private Quaternion Rotating;
	private Vector3 oldVel;
	public Text scoretext;
	private int score;



	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> (); // Makes it a rigidbody


	}
	IEnumerator Start(){ 
		//Debug.Log ("Got to start");
		Vector3 Rndposition = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(4.0f, 8.5f), 0); //Random Serve position
		score = 0; // Update Score to zero
		scoretext.text = "Score: " + score; //Update score text
		yield return new WaitForSeconds (2); //Wait two seconds before serving
		Serve (Rndposition); //Run serve at random position
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
		void Serve (Vector3 touchpos){ // Serve ball at start of game, adds force in a direction.
		
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
	void InGameServe(Vector3 touchpos){ //Serve that happens during the game, happens when bounced off paddle.
		Vector3 dir = touchpos - transform.position;
		dir = dir.normalized; 
		rb.isKinematic = false;
		transform.LookAt (dir);

	}
		


		void FollowTouch(){
		for (int i = 0; i < Input.touches.Length; i++) {
			Touch touch = Input.touches [i];
			Vector3 touchPos3D = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, Camera.main.nearClipPlane)); //Detect length between camera and wall.
			Vector3 newpos = transform.position;
			newpos.x = touchPos3D.x; //Update position
		}
	}


	void OnCollisionEnter(Collision c){
//		if (c.collider.tag == "Player") {
//			ContactPoint cp = c.contacts [0];
//			rb.velocity = Vector3.Reflect (oldVel, cp.normal);
//			//Debug.Log (rb.velocity);
//			if (rb.velocity.z < 19.2f) {
//				rb.velocity += cp.normal * 4f;
//				//Vector3 Rndposition = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(4.0f, 8.5f), 0);
//				//InGameServe (Rndposition);
//
//			}
		//}


		if (c.collider.tag == "Ground") { // Add force upon hitting ground.
			//Debug.Log ("Hits the ground");
//			Vector3 oldVely = rb.velocity;
//			oldVely.y += oldVely.y + 40f;
			rb.AddRelativeForce(transform.up * 50f);
			Debug.Log (rb.velocity.y);

		}
		if (c.collider.tag == "Player") { //Detect collision between ball and paddle, update score.
			score++;
			scoretext.text = "Score: " + score;



		}


	}










}


	