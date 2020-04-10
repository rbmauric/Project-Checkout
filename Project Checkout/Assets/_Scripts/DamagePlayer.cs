using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D pellet)
    {
        if (pellet.CompareTag("Player"))
        {
            pellet.GetComponent<Player>().Damage();
        }
    }

}
