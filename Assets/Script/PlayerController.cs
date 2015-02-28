using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Vector2 speed = new Vector2(1,0);
	GameObject tower;
	bool showConstructionUI;
	
	void Start(){
		showConstructionUI = false;
	}
	
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(speed.x*inputX, 0, speed.y*inputZ);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);

		if (Input.GetButtonDown("Fire1")) {
			Debug.Log("Button A");
		}
		if (Input.GetButtonDown ("Fire2")) {
			Debug.Log("Button B");
		}
		if (Input.GetButtonDown ("Fire3")) {
			Debug.Log("Button X");
		}
		if (Input.GetButtonDown ("LBumper")) {
			Debug.Log("Bumper Left");
		}
		if (Input.GetButtonDown ("RBumper")) {
			Debug.Log("Bumper Right");
		}
	}

	void OnTriggerEnter(Collider other){
		tower = other.gameObject;
		showConstructionUI = true;
	}

	void OnTriggerExit(Collider other){
		tower = null;
		showConstructionUI = false;
	}
}