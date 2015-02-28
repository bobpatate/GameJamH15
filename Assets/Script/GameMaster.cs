using UnityEngine;
using System.Collections;

/*<summary>
 * Game's central entity. Is a singleton.
</summary>*/

public class GameMaster : MonoBehaviour {
	private static GameMaster _instance;
	
	public static GameMaster instance{
		get{
			if(_instance == null){
				_instance = GameObject.FindObjectOfType<GameMaster>();
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	public int currentLevel = 0;

	[SerializeField] private int enemiesToSpawn = 10;
	private int enemiesLeftToSpawn;

	void Awake(){
		if(_instance == null){
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else{
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	void Start(){
		StartLevel (currentLevel);
	}

	void Update(){

	}

	void StartLevel(int currentLevel){
		//enemiesToSpawn += enemiesToSpawn * 1.2;
		enemiesLeftToSpawn = enemiesToSpawn;
	}

	void SpawnEnemy(){

	}

	void DeadEnemy(){
		enemiesLeftToSpawn --;
		//
	}
}
