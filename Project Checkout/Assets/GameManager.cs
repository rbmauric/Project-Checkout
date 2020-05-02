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
        SceneManager.LoadScene(1);
    }

    public static void gameOver()
    {
        SceneManager.LoadScene(2);
        PlayerStats.money = 500;
    }

}
