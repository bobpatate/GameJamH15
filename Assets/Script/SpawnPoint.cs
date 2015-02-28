using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawn(){
		Instantiate(enemyPrefab, transform.position, transform.rotation);
	}
}
