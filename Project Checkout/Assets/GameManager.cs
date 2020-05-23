using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    public static void levelComplete()
    {
        Debug.Log("Level Complete");
        SceneManager.LoadScene(3);
    }

    public static void restartLevel()
    {
        reset();
        SceneManager.LoadScene(1);
    }

    public static void gameOver()
    {
        reset();
        SceneManager.LoadScene(2);
    }

    public static void reset()
    {
        PlayerStats.money = 500;
        PlayerStats.itemCount = 0;
        PlayerCombat.doubleAttack = false;
        PlayerCombat.rangeAttack = false;
        PlayerCombat.projectileAttack = false;
        EnemyManager.aliveEnemies = 0;
        RangeEnemyManager.aliveEnemies = 0;
    }
}
