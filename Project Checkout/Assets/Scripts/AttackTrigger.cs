using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCombat player = GetComponentInParent<PlayerCombat>();
        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (other.tag == "Enemy")
        {
            Debug.Log("Hit");

            if (gameObject.name == "Range Attack Hitbox")
            {
                enemy.takeDamage(player.rangeAttackDamage);
                Debug.Log("Range Attack");
                return;
            }
            enemy.takeDamage(player.attackDamage);
            Debug.Log("Regular Attack");
        }
    }

}
