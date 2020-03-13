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
    //    countdownText.color = gradient_text.Evaluate(startingTime); 
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        countdownText.color = gradient_text.Evaluate(currentTime); //

        if (currentTime <= 0)
        {
            //Kinda suppose to deactivate the timer when certain requiement met 
            //Possible to use later on
            //  CountdownText.gameobject.SetActive(false); 
            currentTime = 0;
        }
        //   if(currentTime>=3.5f){CountDownText.color = Color.black;}
        //   if (currentTime < 3.5f) { CountDownText.color = Color.red; }
        // For reference

    }
}
