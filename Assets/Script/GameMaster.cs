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

	[SerializeField] private float enemySpawnDelay = 5.0f;

	[SerializeField] private int nb_enemy_tot = 10;
	private int enemiesLeftToSpawn;
	private bool round_is_success = true; 
    private int nb_enemy_scared = 0;
    private float xp_won = 0;
    private float life_left = 3;

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
		if(Time.deltaTime % enemySpawnDelay < 1){
			//Debug.Log ("Spawn");
		}
	}

	void StartLevel(int currentLevel){
		nb_enemy_tot += Mathf.RoundToInt(nb_enemy_tot * 1.2f);
		enemiesLeftToSpawn = nb_enemy_tot;
	}

	void SpawnEnemy(){

	}

	void DeadEnemy(){
		enemiesLeftToSpawn --;
		nb_enemy_scared ++;
	}

    public bool isRoundSuccess()
    {
        return round_is_success;
    }

    public int getNbEnemyScared()
    {
        return nb_enemy_scared;
    }

    public int getNbTotEnemy()
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
