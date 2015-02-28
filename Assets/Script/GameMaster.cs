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

	public GameObject guiGO;
	public GameObject endGameMenuGO;
	private ConstructionGUI gui;
	private EndRoundScreenScript endGameMenu;

	private string currentGamePhase = "Day"; //or "Night"
	private int dayTimer = 0;
	private int roundTotalTime = 0;

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

		gui = guiGO.GetComponent<ConstructionGUI>();
		endGameMenu = endGameMenuGO.GetComponent<EndRoundScreenScript>();
	}


	void Update(){
		roundTotalTime = Mathf.RoundToInt(Time.time);

		if((roundTotalTime % enemySpawnDelay) == 0){
			Debug.Log(roundTotalTime);
		}

	}

	private void StartLevel(int currentLevel){
		Time.timeScale = 1; //unpause game

		roundTotalTime = 0;

		nb_enemy_tot += Mathf.RoundToInt(nb_enemy_tot * 1.2f);
		enemiesLeftToSpawn = nb_enemy_tot;
	}

	private void EndLevel(){
		endGameMenu.Display();
	}

	private void SpawnEnemy(){

	}


	public void DeadEnemy(){
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
