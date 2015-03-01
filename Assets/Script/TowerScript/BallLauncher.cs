﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallLauncher : Towers
{
    
    public Transform ball_prefab;
    public float ball_speed = 100;
    float max_nb_ball_load;
    float nb_ball_load;
    public float BuildingMultiplicator = 1.6f;

    // Use this for initialization
    protected override void Start()
    {
        player = GameObject.Find("Player");

        maxLevel = 10;
        max_radius = 25;
        min_reload_time = 1;
        base_radius = 7;
        base_reload_time = 5;
        base_enhance_time = 2;
        targets = new HashSet<Transform>();
        fear_damage = 0;

        level = 1;
        sc = transform.GetChild(0).GetComponent<SphereCollider>();
        sc.radius = base_radius;
        reload_time = base_reload_time;
        max_nb_ball_load = 1;
        nb_ball_load = max_nb_ball_load;
        next_attack_time = Time.time;

        base_building_time = player.GetComponent<CharacterStats>().getBuildingSpeed() * BuildingMultiplicator;
    }

    protected override void Shoot()
    {
        Transform target = getTarget();
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);
            if (nb_ball_load > 0)
            {
				AudioManager.instance.playShootSound();
				Transform tmpBall = (Transform)Instantiate(ball_prefab, transform.position, Quaternion.identity);
                //tmpBall.rigidbody.AddForce(direction * ball_speed);
                tmpBall.GetComponent<BallTrigger>().setObjective(target);
                --nb_ball_load;
                next_attack_time = Time.time + reload_time;
            }
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
        if(nb_ball_load == 0)
        {
            isReloading = true;
            nb_ball_load = max_nb_ball_load;
            next_attack_time = Time.time + reload_time;
        }
    }

    public override void upgrade()
    {
        ++level;
        isEnhancing = true;
        float ratio = (level - 1) / (maxLevel - 1);
        sc.radius = base_radius + (max_radius - base_radius) * ratio;
        reload_time = base_reload_time + (min_reload_time - base_reload_time) * ratio;
    }


}
