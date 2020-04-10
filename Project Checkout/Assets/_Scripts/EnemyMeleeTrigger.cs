using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D attack)
    {
        if (attack.CompareTag("Player"))
        {
            attack.GetComponent<Player>().Damage();
        }
    }
}
