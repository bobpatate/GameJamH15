﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Towers : MonoBehaviour {

    protected static readonly float building_time = 1000;
    protected float maxLevel;
    protected float max_radius;
    protected float min_reload_time;
    protected float base_radius;
    protected float base_reload_time;
    protected float level;
    protected float reload_time;
    protected float next_attack_time;
    protected HashSet<Transform> targets;
    protected float fear_damage;

    protected abstract void Start();

    // Update is called once per frame
    protected virtual void Update()
    {
        removeTargetThatEnded();
        if (targets.Count > 0 && Time.time >= next_attack_time)
        {
            Shoot();
        }
    }

    protected abstract void Shoot();

    public virtual void addTarget(Transform target)
    {
        targets.Add(target);
    }

    public virtual void removeTarget(Transform target)
    {
        targets.Remove(target);
    }

    protected virtual void removeTargetThatEnded()
    {
        foreach (Transform t in targets)
        {
            if (t == null)
            {
                targets.Remove(t);
            }
        }
    }

    public abstract void reload();

    public abstract bool upgrade();

    public virtual float getLevel()
    {
        return level;
    }

    public virtual float getReloadTime()
    {
        return reload_time;
    }

    public virtual float getFearDamage()
    {
        return fear_damage;
    }
}
