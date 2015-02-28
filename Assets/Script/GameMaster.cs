﻿using UnityEngine;
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
	[SerializeField] private int enemyTotal = 10;
	[SerializeField] private float percentageToKill = 0.5f;

	internal int enemiesToKillToWin; //percentageToKill*enemyTotal

	public GameObject[] spawnPoints;

	public GameObject guiGO;
	public GameObject endGameMenuGO;
	private ConstructionGUI gui;
	private EndRoundScreenScript endGameMenu;

	private string currentGamePhase = "Day"; //or "Night"
	private int dayTimer = 30; //seconds to place towers during day
	private int roundTotalTime = 0;
	private bool canSpawn = true;
	private int spawnRandomizer = 0; //doesn't really work ATM

	private int enemiesSpawned = 0; //number of enemies already spawned
	private int enemiesLeft; //number of enemies that are in game or not yet spawned
	private int enemiesInGame = 0; //number of enemies in game
	private bool round_is_success = false; 
    private int nb_enemy_scared = 0;
    private float xp_won = 0;
    private float life_left = 3;

	private GameObject playerRef;

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
		Random.seed = (int)System.DateTime.Now.Ticks;

		playerRef = GameObject.Find("Player");

		StartLevel (currentLevel);

		gui = guiGO.GetComponent<ConstructionGUI>();
		endGameMenu = endGameMenuGO.GetComponent<EndRoundScreenScript>();
	}


	void Update(){
		//Endgame
		if(enemiesLeft <= 0){
			if(nb_enemy_scared >= enemiesToKillToWin){
				round_is_success = true;
			}
			else{
				round_is_success = false;
			}
			
			enemiesInGame ++;
			enemiesSpawned ++;
			
			EndLevel();
		}
	}

	public void StartNextLevel(){
		currentLevel++;
		StartLevel(currentLevel);
	}

	//Initialize number of enemies to spawn
	private void StartLevel(int currentLevel){
		Time.timeScale = 1; //unpause game
		//playerRef.SetActive(true);
		playerRef.transform.GetChild(0).renderer.enabled = true;
		playerRef.GetComponent<PlayerController> ().enabled = true;

		InvokeRepeating("SpawnEnemy", 0, enemySpawnDelay);

		roundTotalTime = 0;

		if(currentLevel != 0)
			enemyTotal += Mathf.RoundToInt(enemyTotal * 1.2f);
		enemiesLeft = enemyTotal;

		enemiesToKillToWin = (int)(percentageToKill*enemyTotal);

		enemySpawnDelay -= currentLevel*0.4f;
	}

	//Show endgame, pause game
	private void EndLevel(){
		Time.timeScale = 0; //pause game
		//playerRef.SetActive(false);
		playerRef.transform.GetChild(0).renderer.enabled = false;
		playerRef.GetComponent<PlayerController> ().enabled = false;

		endGameMenu.Display();
	}

	//Spawn enemy at random spawn point
	private void SpawnEnemy(){
		//In game. Spawn enemies
		if(enemiesSpawned < enemyTotal){
			spawnRandomizer = Random.Range(0,1);

			int selected = Random.Range(0, spawnPoints.Length);
			spawnPoints[selected].GetComponent<SpawnPoint>().spawn();
			
			enemiesInGame ++;
			enemiesSpawned ++;
		}
		else{
			CancelInvoke();
		}
	}

	//Enemy got through
	public void safeEnemy(){
		enemiesInGame --;
		enemiesLeft --;
	}

	//Scared an enemy successfully
	public void killedEnemy(){
		enemiesInGame --;
		enemiesLeft --;
		nb_enemy_scared ++;

		xp_won += 1;
		playerRef.GetComponent<CharacterXP>().addXP(1);
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
		return enemyTotal;
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
