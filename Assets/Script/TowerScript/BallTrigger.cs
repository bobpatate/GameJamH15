using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBehaviour>().setStun(5000);
            Destroy(gameObject);
        }
    }
}
