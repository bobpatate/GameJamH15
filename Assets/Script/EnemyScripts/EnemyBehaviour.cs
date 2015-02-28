using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    private float fear = 0.0f;
    private NavMeshAgent agent;
	private bool isScared = false;
    private float stun_end_time;

    public float maxFear = 100.0f;
    public Vector3 targetPoint = new Vector3(20, 20, 20); //Determine it through an empty GameObject corresponding to the exit of the map
 
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= stun_end_time)
        {
            agent.enabled = true;
            agent.SetDestination(targetPoint);
        }
        else
        {
            agent.enabled = false;
        }
    }

    public void addFear(float fear_to_add)
    {
        fear += fear_to_add;
        checkHorrified();
    }

    public float getFear()
    {
        return fear;
    }

    public float getMaxFear()
    {
        return maxFear;
    }

    private void checkHorrified()
    {
        if (!isScared && fear >= maxFear)
        {
            launchHorrifiedAnimation();
			isScared = true;
        }
    }

    private void launchHorrifiedAnimation()
    {
        int nbOfSpawn = GameMaster.instance.spawnPoints.Length;
        int spawn = Random.Range(0, nbOfSpawn); //The enemy will run randomly to a spawn point
        GameObject spawnPoint = GameMaster.instance.spawnPoints[spawn];
        targetPoint = spawnPoint.transform.position;
		agent.speed = agent.speed*2;
    }

    public void setStun(float duration)
    {
        stun_end_time = Time.time + duration;
    }
}
