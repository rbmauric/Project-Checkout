using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;  //??Outdated??
using UnityEngine.UIElements;  // New?

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //Setting Max Health
    public void SetMaxHealth(int health) 
    {
    //    slider.maxValue = health;   //Suppose to set max health, but maxValue isn't a definiton?
        slider.value = health;

     //   fill.color = gradient.Evaluate(1f);  //Set Max Health to color on the right
    }
    
    //Setting health slider
    public void SetHealth(int health)
    {
        slider.value = health;

       // fill.color = gradient.Evaluate(slider.normalizedValue);
       // Update Health Bar color to whatever value the slider has
    }

}