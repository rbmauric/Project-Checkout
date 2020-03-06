using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * 2.5f, ForceMode2D.Impulse);

            grounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground") && grounded == false)
        {
            grounded = true;
        }
    }
}
