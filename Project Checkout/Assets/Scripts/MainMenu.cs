using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator start_animator;
    public Animator exit_animator;
    public Animator options_animator;
    public Animator about_us_animator;

    public GameObject aboutUs;
    public GameObject paidMembers;
    private bool pm;

    public SoundManager sm;

    //private bool start_pressed = false;
    //private bool exit_pressed = false;
    //private bool options_pressed = false;
    //private bool about_us_pressed = false;

    private void Start()
    {
        sm.Play("Main Menu");
    }

    public void StartGame()
    {
        Debug.Log("Start");
        start_animator.SetTrigger("pressed");
        sm.Play("Button Press");
        StartCoroutine(buttonPressed());   
    }

    public void Exit()
    {
        Debug.Log("Exit");
        exit_animator.SetTrigger("pressed");
        sm.Play("Button Press");
        Application.Quit();
    }

    public void Options()
    {
        Debug.Log("Options");
        options_animator.SetTrigger("pressed");
        sm.Play("Button Press");
    }

    public void AboutUsOpen()
    {
        Debug.Log("About Us: Open");
        if (pm)
        {
            aboutUs.SetActive(true);
            paidMembers.SetActive(false);
            pm = false;
        }
        else
        {
            about_us_animator.SetTrigger("pressed");
            sm.Play("Button Press");
            aboutUs.SetActive(true);
        }
    }

    public void AboutUsClose()
    {
        Debug.Log("About Us: Close");
        aboutUs.SetActive(false);
        paidMembers.SetActive(false);
    }

    public void PaidMembersOpen()
    {
        Debug.Log("About Us: Paid Members");
        aboutUs.SetActive(false);
        paidMembers.SetActive(true);
        pm = true;
    }

    IEnumerator buttonPressed()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


