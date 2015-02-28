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

    //TODO Take care of the following var please, my GameMaster :3
    bool round_is_success = true; 
    float nb_enemy_scared = 0;
    float nb_enemy_tot = 0;
    float xp_won = 0;
    float life_left = 3;




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

    public bool isRoundSuccess()
    {
        return round_is_success;
    }

    public float getNbEnemyScared()
    {
        return nb_enemy_scared;
    }

    public float getNbTotEnemy()
    {
        return nb_enemy_tot;
    }

    public float getNbXPWon()
    {
        return xp_won;
    }

    public float getLifeLeft()
    {
        return life_left;
    }
}
