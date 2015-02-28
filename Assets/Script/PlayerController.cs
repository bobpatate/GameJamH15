using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Vector2 speed = new Vector2(1,0);
	GameObject tower;
	bool showConstructionUI;
	private bool axisInUse;
	public GameObject mGui;
	
	void Start(){
		showConstructionUI = false;
		axisInUse = false;
	}
	
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputZ = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(speed.x*inputX, 0, speed.y*inputZ);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);

		if (Input.GetButtonDown("Fire1")) {
			Debug.Log("Button A");
			float dist = Mathf.Sqrt(Mathf.Pow(tower.transform.position.x - transform.position.x, 2) + Mathf.Pow(tower.transform.position.z - transform.position.z, 2));
			if(dist > 2){
				//On construit
			}else{
				//On construit pas
			}
		}
		if (Input.GetButtonDown ("Fire2")) {
			Debug.Log("Button B");
		}
		if (Input.GetButtonDown ("Fire3")) {
			Debug.Log("Button X");
		}

		if (Input.GetAxisRaw ("LTrigger") != 0) {
			if(!axisInUse){
				mGui.GetComponent<ConstructionGUI>().changeGUI(-1);
				axisInUse = true;
			}
		}

		if (Input.GetAxisRaw ("RTrigger") != 0) {
			if(!axisInUse){
				mGui.GetComponent<ConstructionGUI>().changeGUI(1);
				axisInUse = true;
			}
		}
		if (Input.GetAxisRaw ("RTrigger") == 0 && Input.GetAxisRaw ("LTrigger") == 0) {
			axisInUse = false;
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