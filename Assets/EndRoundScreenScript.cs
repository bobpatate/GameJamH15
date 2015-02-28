﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndRoundScreenScript : MonoBehaviour
{

    readonly string ROUND_RESULT_OK = "Success";
    readonly string ROUND_RESULT_FAIL = "Failure";
    readonly string ENEMY_SCARED = "Enemy scared: ";
    readonly string EXPERIENCE_WON = "Experience won: ";
    readonly string LEVEL = "Level: ";
    readonly string EXPERIENCE = "Experience: ";
    readonly string LIFE_LEFT = "Life left: ";
    readonly string M_SPEED = "Movement speed\n";
    readonly string B_SPEED = "Building speed\n";
    readonly string E_AND_R_SPEED = "Enhancement and\nreload speed";
    readonly string STAT_POINTS_TO_SPEND = "Stat points to spend: ";
    readonly string NEXT_ROUND_OK = "Start next round";
    readonly string NEXT_ROUND_FAIL = "Try again";

    // Use this for initialization
    void Start()
    {
        //Display();
        Hide();
    }

    public void Display()
    {
        GameMaster gm = GameMaster.instance;
        CharacterXP playerXP = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterXP>();
        CharacterStats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        foreach (Transform child in transform)
        {
            switch (child.name)
            {
                case "roundResult":
                    if (gm.isRoundSuccess())
                    {
                        child.GetComponent<Text>().text = ROUND_RESULT_OK;
                    }
                    else
                    {
                        child.GetComponent<Text>().text = ROUND_RESULT_FAIL;
                    }
                    break;
                case "enemyScared":
                    child.GetComponent<Text>().text = ENEMY_SCARED + gm.getNbEnemyScared() + " / " + gm.getNbTotEnemy();
                    break;
                case "experienceWon":
                    child.GetComponent<Text>().text = EXPERIENCE_WON + gm.getNbXPWon();
                    break;
                case "level":
                    child.GetComponent<Text>().text = LEVEL + playerXP.getCurrentLevel();
                    break;
                case "experience":
                    child.GetComponent<Text>().text = EXPERIENCE + playerXP.getCurrentXP() + " / " + playerXP.getXPNeedToUp();
                    break;
                case "lifeLeft":
                    child.GetComponent<Text>().text = LIFE_LEFT + gm.getLifeLeft();
                    break;
                case "mSpeed":
                    child.GetChild(0).GetComponent<Text>().text = M_SPEED + "\n\n" + playerStats.getStatMovementSpeed();
                    break;
                case "bSpeed":
                    child.GetChild(0).GetComponent<Text>().text = B_SPEED + "\n\n" + playerStats.getStatBuildingSpeed();
                    break;
                case "eAndRSpeed":
                    child.GetChild(0).GetComponent<Text>().text = E_AND_R_SPEED + "\n\n" + playerStats.getStatEnhancementAndReloadSpeed();
                    break;
                case "statPointsToSpend":
                    child.GetComponent<Text>().text = STAT_POINTS_TO_SPEND + playerXP.getStatPointsToSpend();
                    break;
                case "nextRound":
                    if (gm.isRoundSuccess())
                    {
                        child.GetChild(0).GetComponent<Text>().text = NEXT_ROUND_OK;
                    }
                    else
                    {
                        child.GetChild(0).GetComponent<Text>().text = NEXT_ROUND_FAIL;
                    }
                    break;
            }
        }
        GameObject.FindWithTag("Player").gameObject.SetActive(false);
        transform.parent.GetChild(0).gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        GameObject.FindWithTag("Player").gameObject.SetActive(true);
        transform.parent.GetChild(0).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

}
