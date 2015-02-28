using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

    private Transform target = null;
    private float nextAttackTime = 0.0f;

    public static bool isBeingHitted;
    public float reloadTime = 60.0f;
    public float damage = 10.0f;

	// Use this for initialization
	void Start () {
        nextAttackTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (target && (Time.time >= nextAttackTime))
        {
            target.GetComponent<EnemyBehaviour>().addFear(damage);
            nextAttackTime = Time.time + reloadTime;
        } 		
	}

    void OnTriggerEnter( Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            target = other.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform == target)
        {
            target = null;
        }
    }
}
