using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public SoundManager sm;
    public void Start()
    {
        sm.Play("Win Screen");
    }

    public void PlayAgain()
    {
        Debug.Log("PlayAgain");
        PlayerStats.itemCount = 0;
        PlayerCombat.doubleAttack = false;
        PlayerCombat.rangeAttack = false;
        PlayerCombat.projectileAttack = false;
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
