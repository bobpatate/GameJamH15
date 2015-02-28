﻿using UnityEngine;
using System.Collections;

public class TowerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider other)
	{
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Enemy") {
			transform.parent.GetComponent<TowerScript>().setTarget(other.gameObject.transform);
		}
		if (other.gameObject.tag.Equals("Player")) {
			other.gameObject.GetComponent<PlayerController>().getTriggerInfo(gameObject);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.transform == transform.parent.GetComponent<TowerScript>().getTarget())
		{
			transform.parent.GetComponent<TowerScript>().setTarget(null);
		}
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerController>().getTriggerInfo(null);
		}
	}
}
