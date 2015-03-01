using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Enemy")){
			AudioManager.instance.playSafeSound();
			Destroy(other.gameObject);
			GameMaster.instance.safeEnemy();
		}
	}
}
