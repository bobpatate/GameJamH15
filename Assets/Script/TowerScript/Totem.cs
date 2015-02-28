using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Totem : Towers {

    SphereCollider sc;

	// Use this for initialization
    protected override void Start()
    {
        maxLevel = 10;
        max_radius = 25;
        min_reload_time = 10;
        base_radius = 7;
        base_reload_time = 60;
        targets = new HashSet<Transform>();
        fear_damage = 10;

        level = 1;
        sc = transform.GetChild(0).GetComponent<SphereCollider>();
        sc.radius = base_radius;
        reload_time = base_reload_time;
        next_attack_time = Time.time;
    }

    protected override void Shoot()
    {
        foreach(Transform target in targets) {
            target.GetComponent<EnemyBehaviour>().addFearDamage(fear_damage);
        }

    }

    public override void reload()
    {
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
