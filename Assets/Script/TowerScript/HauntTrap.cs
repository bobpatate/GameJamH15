using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HauntTrap : Towers {

    SphereCollider sc;

    float max_nb_ball_load;
    float nb_ball_load;

    // Use this for initialization
    protected override void Start()
    {
        maxLevel = 10;
        max_radius = 25;
        min_reload_time = 0.1f;
        base_radius = 7;
        base_reload_time = 1.0f;
        targets = new HashSet<Transform>();
        fear_damage = 100;

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
        if(target != null)
        {
            if (nb_ball_load >= 1)
            {
                target.GetComponent<EnemyBehaviour>().addFearDamage(fear_damage);
                nb_ball_load--;
            }
        }
    }

    private Transform getTarget()
    {
        return targets.GetEnumerator().Current;
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
    }
}
