using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Gradient gradient_text;

    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
        
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
            currentTime = 0;
            countdownText.color = Color.black;
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
