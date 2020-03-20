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

        Destroy(gameObject, 0.4f);
    }

    void shootRight()
    {
        rb.velocity = transform.right * projSpeed;
    }

    void shootLeft()
    {
        rb.velocity = transform.right * (-1 * projSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().takeDamage(projDamage);
            Destroy(gameObject);
        }
    }
}
