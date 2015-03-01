using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Towers : MonoBehaviour {

    [SerializeField] protected float base_building_time;
    protected float currentBuildingTime = 0.0f;
    protected float startTime = 0.0f;

    protected bool hasJustBeenPlaced = true;

    protected float maxLevel;
    protected float max_radius;
    protected float min_reload_time;
    protected float base_radius;
    protected float base_reload_time;
    protected float level;
    protected float reload_time;
    protected float next_attack_time;
    protected HashSet<Transform> targets;
    [SerializeField] protected float fear_damage;

    protected abstract void Start();

    // Update is called once per frame
    protected virtual void Update()
    {
        if(hasJustBeenPlaced)
        {
            startTime = Time.time;
            hasJustBeenPlaced = false;
        }

        currentBuildingTime = Time.time - startTime;

        removeTargetThatEnded();

        if (targets.Count > 0 && Time.time >= next_attack_time && currentBuildingTime >= base_building_time)
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
        targets.RemoveWhere(t => t == null);
    }

    public abstract void reload();

    public abstract void upgrade();

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

	public virtual bool canUpgrade(){
		return (level < maxLevel);
	}

    public virtual float getBuildingTime()
    {
        return base_building_time;
    }

    public virtual float getCurrentBuildingTime()
    {
        return currentBuildingTime;
    }
}
