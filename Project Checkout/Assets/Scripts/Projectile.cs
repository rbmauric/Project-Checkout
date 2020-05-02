using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int projDamage = 20;
    public float projSpeed = 4.0f;
    public Rigidbody2D rb;
    public bool right;

    private void Update()
    {
       if (right)
        {
            shootRight();
        }
       else
        {
            shootLeft();
        }

        Destroy(gameObject, 5);
    }

    void shootRight()
    {
        rb.velocity = transform.right * projSpeed;
    }

    void shootLeft()
    {
        rb.velocity = transform.right * (-1 * projSpeed);
    }
}
