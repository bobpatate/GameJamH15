using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    private int spawnRandomizer = 0;

    public GameObject[] enemyToSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawn(){
        spawnRandomizer = Random.Range(0, enemyToSpawn.Length);
        Instantiate(enemyToSpawn[spawnRandomizer], transform.position, transform.rotation);
	}

    void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Enemy")
        {
            if(Other.GetComponent<EnemyBehaviour>().getFear() >= Other.GetComponent<EnemyBehaviour>().getMaxFear())
            {
				GameMaster.instance.killedEnemy();
				Destroy(Other.gameObject);
            }
        }

    }
}
