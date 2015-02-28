using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Vector2 speed = new Vector2(1,0);
	
	void Start(){

	}
	
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3
			(speed.x*inputX, 0, speed.y*inputZ);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
	}
}