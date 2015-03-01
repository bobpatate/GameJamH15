using UnityEngine;
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
			transform.parent.GetComponent<Towers>().addTarget(other.gameObject.transform);
		}
		if (other.gameObject.tag.Equals("Player")) {
			Debug.Log("Player In");
			other.gameObject.GetComponent<PlayerController>().getTriggerInfo(gameObject);
		}
	}
	
	void OnTriggerExit(Collider other)
	{
        if (other.gameObject.tag == "Enemy")
        {
            transform.parent.GetComponent<Towers>().removeTarget(other.gameObject.transform);
        }
		if (other.gameObject.tag == "Player") {
			Debug.Log("Player Out");
			other.gameObject.GetComponent<PlayerController>().getTriggerInfo(null);
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log("Player Stay");
			other.gameObject.GetComponent<PlayerController>().getTriggerInfo(gameObject);
		}
	}
}
