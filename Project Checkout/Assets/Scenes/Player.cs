using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //Setting the Player health to max
    }

    // Update is called once per frame
    void Update()
    {
        //PlacerHolder to get the player to take damage
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }


    }

    //The damage subtraction
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

}
