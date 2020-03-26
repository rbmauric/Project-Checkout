using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;



public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    //------------------------------------
    public float speed = 5;

    public float jumpForce;

    [HideInInspector]
    public Rigidbody2D playerRB;

    private float movementInput;

    //------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        //Setting the Player health to max
        //----------------------------------
        playerRB = GetComponent<Rigidbody2D>();
    }

    //-------------------------------------------
    private void FixedUpdate()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        //Horizontal Input

        playerRB.velocity = new Vector2(movementInput * speed, playerRB.velocity.y);

    }
    //-------------------------------------------

    // Update is called once per frame
    void Update()
    {
        //PlacerHolder to get the player to take damage
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        //-------------------------------
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }


    }

    //------------------------------------
    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }
    //------------------------------------

    //The damage subtraction
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

}
