using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SoundManager sm;

    private void Start()
    {
        sm.Play("Game Over");
    }

    public void PlayAgain()
    {
        Debug.Log("PlayAgain");
        PlayerStats.resetStats();
        EnemyManager.aliveEnemies = 0;
        EnemyManager.spawnerActive = true;
        RangeEnemyManager.aliveEnemies = 0;
        RangeEnemyManager.spawnerActive = true;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu");
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
