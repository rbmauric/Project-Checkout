using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
        }
    }
}
