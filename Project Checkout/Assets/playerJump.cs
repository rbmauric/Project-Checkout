using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;

    public bool grounded = false;//initially floats above surface

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//reference to Rigidbody in character
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && grounded)//if jump button is pressed and character is grounded
        {
            rb.AddForce(Vector2.up * 2.5f, ForceMode2D.Impulse);//make character jump
        }
    }

    void OnCollisionEnter2D(Collision2D collision)//when player hits ground/ground checking
    {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)//when player stops hitting ground
    {
        grounded = false;
    }
}
