using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Towers : MonoBehaviour {

    public static readonly float building_time = 1000;
    protected float maxLevel;
    public float max_radius;
    public float min_reload_time;
    public float base_radius;
    public float base_reload_time;
    protected float level;
    protected float reload_time;
    protected float next_attack_time;
    protected HashSet<Transform> targets;
    public float fear_damage;

    protected abstract void Start();

    // Update is called once per frame
    protected virtual void Update()
    {
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
