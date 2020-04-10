using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().takeDamage(40);
            Destroy(gameObject);
        }
        else if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
