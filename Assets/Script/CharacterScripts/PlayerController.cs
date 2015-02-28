using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	GameObject tower = null;
	bool showConstructionUI;
	private bool axisInUse;
    private ushort towerInUse = 0;

    public Vector2 speed = new Vector2(1, 0);
    public GameObject mGui;
    public GameObject[] spawnableTowers;
	
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

        Quaternion rot = new Quaternion();
        rot.SetLookRotation(movement.normalized);
        transform.GetChild(0).rotation = rot;

        if (Input.GetButtonDown("Fire1"))
        {
			Debug.Log("Button A");
			if(tower != null){
				Debug.Log ("On entre");
				float dist = Mathf.Sqrt(Mathf.Pow(tower.transform.position.x - transform.position.x, 2) + Mathf.Pow(tower.transform.position.z - transform.position.z, 2));
				if(dist > 5){
					//On construit
                    GameObject t = (GameObject)Instantiate(spawnableTowers[towerInUse], transform.position, spawnableTowers[towerInUse].transform.rotation);
				}else{
					//On construit pas
				}
			}else{
				Debug.Log ("On entre pas");
				//On construit
                GameObject t = (GameObject)Instantiate(spawnableTowers[towerInUse], transform.position, spawnableTowers[towerInUse].transform.rotation);
			}
		}
		if (Input.GetButtonDown ("Fire2")) {
			Debug.Log("Button B");
		}
		if (Input.GetButtonDown ("Fire3")) {
			Debug.Log("Button X");
		}

		if (Input.GetAxisRaw ("LTrigger") != 0 || Input.GetKeyDown(KeyCode.Q)) {
			if(!axisInUse)
            {
                if(towerInUse == 0)
                {
                    towerInUse = 2;
                }
                else
                {
                    towerInUse--;
                }
				mGui.GetComponent<ConstructionGUI>().changeGUI(towerInUse);
				axisInUse = true;
			}
		}

		if (Input.GetAxisRaw ("RTrigger") != 0 || Input.GetKeyDown(KeyCode.E)) {
			if(!axisInUse)
            {
                if (towerInUse == 2)
                {
                    towerInUse = 0;
                }
                else
                {
                    towerInUse++;
                }
				mGui.GetComponent<ConstructionGUI>().changeGUI(towerInUse);
				axisInUse = true;
			}
		}

		if (Input.GetAxisRaw ("RTrigger") == 0 && Input.GetAxisRaw ("LTrigger") == 0) {
			axisInUse = false;
		}

		if (Input.GetAxis("HDPad") < 0) {
			//appel d'une fonction pour décrémenter
		}
		if (Input.GetAxis("HDPad") > 0) {
			//appel d'une fonction pour incrémenter
		}
	}

	public void getTriggerInfo(GameObject tow){
		tower = tow;
	}

	/*void OnTriggerEnter(Collider other){
        if(other.tag == "tower")
        {
            tower = other.gameObject;
            showConstructionUI = true;
        }
	}

	void OnTriggerExit(Collider other){
		tower = null;
		showConstructionUI = false;
	}*/
}