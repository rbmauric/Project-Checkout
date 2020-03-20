using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player hurt");
            other.GetComponent<PlayerStats>().takeDamage(50);
        }
    }
}

