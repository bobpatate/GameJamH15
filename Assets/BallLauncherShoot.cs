using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallLauncherShoot : MonoBehaviour
{
    public static readonly float building_time = 1000;
    public Transform ball_prefab;
    float maxLevel = 10;
    public float max_radius = 25;
    public float min_reload_time = 1000;
    public float base_radius = 7;
    public float base_reload_time = 5000;
    public float ball_speed = 600;
    float level;
    float reload_time;
    float max_nb_ball_load;
    float nb_ball_load;
    float next_attack_time = 0;
    HashSet<Transform> targets;


    // Use this for initialization
    void Start()
    {
        level = 1;
        GetComponent<SphereCollider>().radius = base_radius;
        reload_time = base_reload_time;
        max_nb_ball_load = 1;
        nb_ball_load = max_nb_ball_load;
        next_attack_time = Time.time;
        targets = new HashSet<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0 && Time.time >= next_attack_time)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Transform target = getTarget();
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
            Transform tmpBall = (Transform)Instantiate(ball_prefab, transform.position, Quaternion.identity);
            tmpBall.rigidbody.AddForce(direction * ball_speed);
            --nb_ball_load;
            next_attack_time = Time.time + reload_time;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            targets.Add(other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            targets.Remove(other.transform);
        }
    }

    private Transform getTarget()
    {
        Transform res = null;
        float pathSize = float.MaxValue;
        foreach (Transform t in targets)
        {
            if (t.GetComponent<NavMeshAgent>().remainingDistance < pathSize)
            {
                pathSize = t.GetComponent<NavMeshAgent>().remainingDistance;
                res = t;
            }
        }
        return res;
    }

    public void reload()
    {
        nb_ball_load = max_nb_ball_load;
        next_attack_time = Time.time + reload_time;
    }

    public bool upgrade()
    {
        if (level < maxLevel)
        {
            ++level;
            float ratio = (level - 1) / (maxLevel - 1);
            GetComponent<SphereCollider>().radius = base_radius + (max_radius - base_radius) * ratio;
            reload_time = base_reload_time + (min_reload_time - base_reload_time) * ratio;
            return true;
        }
        else
        {
            return false;
        }
    }
}
