using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Gradient gradient_text;

    public float currentTime = 0f;
    public float buyingTime = 15f;
    public float levelTime = 60f;
    public float addedTime;
    public GameObject[] colliders;
    [SerializeField] Text countdownText;
    public Text levelTimeText;
    public CatalogMenuManager cm;
    public PlayerCombat pc;
    public GameObject menu;

    void Start()
    {
        currentTime = buyingTime;   
    }

    void Update()
    {
        //set time to decrease and text as one whole number
        currentTime -= 1 * Time.deltaTime;

        countdownText.text = currentTime.ToString("00");

        //setting timer color by the current time
        countdownText.color = gradient_text.Evaluate(currentTime); //
        
        if(currentTime <= 5.5f)
        {
            countdownText.fontSize = 50;
            countdownText.color = Color.yellow;
        }

        if(currentTime <= 2.5f)
        {
            countdownText.color = Color.red;
        }

        if (currentTime <= 0)
        {
            //Kinda suppose to deactivate the timer when certain requiement met 
            //Possible to use later on
            //  CountdownText.gameobject.SetActive(false); 
            if (cm.buying)
            {
                currentTime = addedTime + levelTime;
                countdownText.text = currentTime.ToString();
                levelTimeText.text = "";

                for (int i = 0; i < colliders.Length; i++)
                {
                    colliders[i].SetActive(false);
                }

                menu.SetActive(false);
                cm.buying = false;
                pc.isAttacking = false;

            }
            else
            {
                GameManager.gameOver();
                countdownText.color = Color.black;
            }
        }
        //   if(currentTime>=3.5f){CountDownText.color = Color.black;}
        //   if (currentTime < 3.5f) { CountDownText.color = Color.red; }
        // For reference

    }
/*
    //A way to impelment the 0:00 timer by minutes and seconds
    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        GUI.Label(new Rect(10, 10, 250, 100), niceTime);
    }
    */
}
