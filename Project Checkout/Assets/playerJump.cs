using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;//reference to Rigidbody2D on player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//access Rigidbody2D with GetComponent
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))//if jump button called
        {
            Jump();//call jump function
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * 150f);//when called, send a force along Rigidbody2D to make it jump
    }
}   
