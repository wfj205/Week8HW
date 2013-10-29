using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	
	public float moveSpeed;
	public float rotateSpeed;
	public float jumpSpeed;
	public float fallSpeed;
	bool grounded;
	Vector3 moveVector;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = Vector3.zero;
		// 3D platformer, Mario 64
		
		// camera: parent the camera behind the player
		
		
		
		// movement: turn left, right
		/*if(Input.GetKey (KeyCode.A)){
			transform.Rotate (0f,-rotateSpeed*Time.deltaTime,0f);
		}
		
		if(Input.GetKey (KeyCode.D)){
			transform.Rotate (0f,rotateSpeed*Time.deltaTime,0f);
		}*/
		
		float rotation = Input.GetAxis ("Horizontal") * rotateSpeed;
		rotation *= Time.deltaTime;
		transform.Rotate(0,rotation,0);
		
		//Robert's stuff
		/*if(Input.GetKey (KeyCode.W)){
			moveVector += transform.forward;
		}
		if(Input.GetKey (KeyCode.S)){
			moveVector += -transform.forward;
		}*/
		
		//using Input.GetAxis instead of GetKey
		float translation = Input.GetAxis ("Vertical") * moveSpeed;
		translation *= Time.deltaTime;
		transform.Translate (-translation,0,0);
		
		
		//jump
		if(Physics.Raycast (transform.position,-transform.up,1.5f)){
			grounded = true;
			if(Input.GetKeyDown(KeyCode.Space)){
				moveVector += Vector3.up * jumpSpeed;
				audio.Play ();
			}
		}else{
			grounded = false;
		}
		
	}
	
	void FixedUpdate(){
		//rigidbody.AddForce (moveVector * moveSpeed, ForceMode.VelocityChange);
		// movement: move forward, back
		/*if(Input.GetKey (KeyCode.W)){
			rigidbody.AddForce (transform.forward * moveSpeed, ForceMode.VelocityChange);
		}
		
		if(Input.GetKey (KeyCode.S)){
			rigidbody.AddForce (-transform.forward * moveSpeed, ForceMode.VelocityChange);
		}
		
		Ray jumpRay = new Ray(transform.position, -transform.up);
		if(Physics.Raycast(jumpRay, 1.1f)){
			if(Input.GetKeyDown (KeyCode.Space)){
				rigidbody.AddForce (transform.up * jumpSpeed);
			}
		}*/
		if(moveVector != Vector3.zero){
			rigidbody.AddForce (moveVector * moveSpeed, ForceMode.VelocityChange);
		}else{
			rigidbody.AddForce (-rigidbody.velocity + Physics.gravity * fallSpeed, ForceMode.Acceleration);
		}
	}
}
