using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogMenuManager : MonoBehaviour
{
    public static bool opened = false;
    public GameObject catalogMenuUI;
    public GameObject player;
    PlayerCombat combatStats;
    PlayerStats playerStats; 

    void Start()
    {
        combatStats = player.GetComponent<PlayerCombat>();
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            Debug.Log("Menu Opened");

            if (opened)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    void Close()
    {
        catalogMenuUI.SetActive(false);
        Time.timeScale = 1f;
        opened = false;
    }

    void Open()
    {
        catalogMenuUI.SetActive(true);
        Time.timeScale = 0.5f;
        opened = true;

    }

    public void damage2x()
    {
        if (playerStats.money >= 500)
        {
            combatStats.doubleAttack = true;
            playerStats.money -= 500;
        }
    }

    public void piercing()
    {
        if (playerStats.money >= 500)
        {
            combatStats.rangeAttack = true;
            playerStats.money -= 500;
        }
    }

    public void projectile()
    {
        if (playerStats.money >= 500)
        {
            combatStats.projectileAttack = true;
            playerStats.money -= 500;
        }
    }

    public void premium()
    {
        if (playerStats.money >= 2000)
        {
            Debug.Log("Premium powerup not implemented yet");
            playerStats.money -= 2000;
        }
    }

    public void addTime()
    {
        if (playerStats.money >= 300)
        {
            Debug.Log("Time not implemented yet");
            playerStats.money -= 300;
        }
    }

    public void addHealth()
    {
        if (playerStats.money >= 300)
        {
            playerStats.maxHealth += 40;
            playerStats.currentHealth += 40;
            playerStats.money -= 300;
        }
    }
}
