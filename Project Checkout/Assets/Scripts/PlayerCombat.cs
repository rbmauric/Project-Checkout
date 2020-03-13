using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public Transform rangeAttackPoint;
    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 0.5f;
    float nextAttackTime = 0f;
    public bool rangeAttack = false;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Play Attack Animation
        animator.SetTrigger("Attack");

        if (rangeAttack == false)
        {
            //Check if enemy is in range
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            //Damage enemy
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<Enemy>().takeDamage(attackDamage);
            }
        }

        if (rangeAttack == true)
        {
            attackRange = 1.0f;
            //Check if enemy is in range
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            //Damage enemy
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<Enemy>().takeDamage(attackDamage);
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(rangeAttackPoint.position, attackRange);
    }
}
