﻿using UnityEngine;
using System.Collections;

public class CharacterXP : MonoBehaviour
{

    public float base_xp_to_up = 7;
    public float stat_points_per_up = 3;
    float current_level = 1;
    float current_xp = 0;
    float stat_points_to_spend = 0;

    public void addXP(float xp_to_add)
    {
        current_xp += xp_to_add;
        levelUpWhilePossible();
    }

    private void levelUpWhilePossible()
    {
        while (current_xp >= (int) (base_xp_to_up * Mathf.Pow(1.1f, current_level)))
        {
            ++current_level;
            current_xp -= (int)(base_xp_to_up * Mathf.Pow(1.1f, current_level));
            stat_points_to_spend += stat_points_per_up;
        }
    }

    public float getStatPointsToSpend()
    {
        return stat_points_to_spend;
    }


}
