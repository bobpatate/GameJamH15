using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour
{

    public float base_movement_speed = 600;
    public float base_building_speed = 100;
    public float base_enhancement_and_reload_speed = 50;
    float movement_speed = 600;
    float building_speed = 100;
    float enhancement_and_reload_speed = 50;

    float movement_speed_stat = 0;
    float building_speed_stat = 0;
    float enhancement_and_reload_speed_stat = 0;

    public void addMovementSpeedStat()
    {
        ++movement_speed_stat;
        movement_speed = base_movement_speed * (1 + movement_speed_stat / 10);
    }

    public void addBuildingSpeedStats()
    {
        ++building_speed_stat;
        building_speed = base_building_speed * (1 + building_speed_stat / 10);
    }

    public void addEnhancementAndReloadSpeedStat()
    {
        ++enhancement_and_reload_speed_stat;
        enhancement_and_reload_speed = base_enhancement_and_reload_speed * (1 + enhancement_and_reload_speed_stat / 10);
    }

    public float getMovementSpeed()
    {
        return movement_speed;
    }

    public float getBuildingSpeed()
    {
        return building_speed;
    }

    public float getEnhancementAndReloadSpeed()
    {
        return enhancement_and_reload_speed;
    }



}
