using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<PlayerHealth>().removeHp(3);
            Destroy(gameObject);
        }
    }
}
