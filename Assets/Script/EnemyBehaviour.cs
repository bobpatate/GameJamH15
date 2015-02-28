using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public Vector3 targetPoint = new Vector3(20, 20, 20); //Determine it through an empty GameObject corresponding to the exit of the map
    float fear = 0;
    float maxFear = 100;

    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targetPoint);
    }

    public void addFear(float fear_to_add)
    {
        fear += fear_to_add;
        checkHorrified();
    }

    private void checkHorrified()
    {
        if (fear >= maxFear)
        {
            launchHorrifiedAnimation();
        }
    }

    private void launchHorrifiedAnimation()
    {
        Destroy(gameObject); //TODO
    }


}
