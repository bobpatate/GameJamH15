using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Totem : Towers {

    public float buildingMultiplicator = 1.2f;

	// Use this for initialization
    protected override void Start()
    {
        player = GameObject.Find("Player");

        maxLevel = 10;
        max_radius = 25;
        min_reload_time = 0.1f;
        base_radius = 5;
        base_reload_time = 1;
        targets = new HashSet<Transform>();
        //fear_damage = 10;

        level = 1;
        sc = transform.GetChild(0).GetComponent<SphereCollider>();
        sc.radius = base_radius;
        reload_time = base_reload_time;
        next_attack_time = Time.time;

        Debug.Log(player.GetComponent<CharacterStats>().getBuildingSpeed());

        base_building_time = player.GetComponent<CharacterStats>().getBuildingSpeed() * buildingMultiplicator;
    }

    protected override void Shoot()
    {
        foreach(Transform target in targets) {
			if(target){
            	target.GetComponent<EnemyBehaviour>().addFearDamage(Time.deltaTime * fear_damage);
			}
        }
    }

    public override void reload()
    {
        next_attack_time = Time.time;
    }

    public override void upgrade()
    {
        ++level;
        float ratio = (level - 1) / (maxLevel - 1);
        sc.radius = base_radius + (max_radius - base_radius) * ratio;
        reload_time = base_reload_time + (min_reload_time - base_reload_time) * ratio;
    }
}
