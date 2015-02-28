using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	private bool axis2InUse = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			if(!transform.GetComponent<EndGameMenu>().isInSubMenu()){
				if(transform.GetComponent<EndGameMenu>().getCurPos() == 0){
					transform.GetComponent<EndGameMenu>().changeMenu();
				}else{

				}
			}else{
				if(transform.GetComponent<EndGameMenu>().getCurPos() == 0){
					
				}if(transform.GetComponent<EndGameMenu>().getCurPos() == 1){
					
				}else{
					
				}
			}
		}
		if (Input.GetButtonDown ("Fire2")) {
			transform.GetComponent<EndGameMenu>().changeMenu();
		}

		if (Input.GetAxis("HDPad") < 0) {
			if(!axis2InUse){
				transform.GetComponent<EndGameMenu>().changePos(-1);
				axis2InUse = true;
			}
		}
		if (Input.GetAxis("HDPad") > 0) {
			if(!axis2InUse){
				transform.GetComponent<EndGameMenu>().changePos(1);
				axis2InUse = true;
			}
		}
		if (Input.GetAxis ("HDPad") == 0) {
			axis2InUse = false;
		}
	}
}
