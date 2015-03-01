using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallLauncher : Towers
{
    SphereCollider sc;
    public Transform ball_prefab;
    public float ball_speed = 600;
    float max_nb_ball_load;
    float nb_ball_load;


    // Use this for initialization
    protected override void Start()
    {
        maxLevel = 10;
        max_radius = 25;
        min_reload_time = 1000;
        base_radius = 7;
        base_reload_time = 5000;
        targets = new HashSet<Transform>();
        fear_damage = 0;

        level = 1;
        sc = transform.GetChild(0).GetComponent<SphereCollider>();
        sc.radius = base_radius;
        reload_time = base_reload_time;
        max_nb_ball_load = 1;
        nb_ball_load = max_nb_ball_load;
        next_attack_time = Time.time;
    }

    protected override void Shoot()
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

    public override void reload()
    {
        nb_ball_load = max_nb_ball_load;
        next_attack_time = Time.time + reload_time;
    }

    public override void upgrade()
    {
        ++level;
        float ratio = (level - 1) / (maxLevel - 1);
        sc.radius = base_radius + (max_radius - base_radius) * ratio;
        reload_time = base_reload_time + (min_reload_time - base_reload_time) * ratio;
    }


}
