using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyProjectile : MonoBehaviour
{
    public int projDamage = 30;
    public float projSpeed = 2f;
    private Rigidbody2D rb;

    public bool right = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shoot();
    }

    private void Update()
    {
        Destroy(gameObject, 5);
    }

    void shoot()
    {
        if (right)
        {
            rb.velocity = transform.right * projSpeed;
        }
        else
        {
            rb.velocity = -(transform.right) * projSpeed;
        }

    }
}
