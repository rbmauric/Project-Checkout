using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    public GameObject attackHitBox;
    public GameObject rangeAttackHitBox;

    public int attackDamage = 40;
    public int rangeAttackDamage = 30;
    public float attackSpeed = 0.7f;
    private float debuffTimer;

    public bool doubleAttack = false;
    public bool rangeAttack = false;
    public bool projectileAttack = false;
    public bool isAttacking = false;

    private void Start()
    {
        debuffTimer = 0f;
        attackHitBox.SetActive(false);
        rangeAttackHitBox.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking && GetComponent<PlayerMovement>().groundCheck)
        {

            //Play Attack Animation
            animator.SetTrigger("Attack");

            isAttacking = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        PlayerMovement player = GetComponent<PlayerMovement>();
        if (rangeAttack == true)
        {
            rangeAttackHitBox.SetActive(true);
            debuffTimer++;
        }

        if (doubleAttack == true)
        {
            attackDamage = 60;
            rangeAttackDamage = 40;
            debuffTimer++;
            GetComponentInParent<ProjectileManager>().proj.projDamage = 40;
        }

        if (projectileAttack == true)
        {
            GetComponentInParent<ProjectileManager>().instantiateProjectile();
            debuffTimer++;
        }

        attackHitBox.SetActive(true);
        

        if (debuffTimer > 1)
        {
            StartCoroutine(player.cantMove(player.moveTime * debuffTimer));
            player.speed /= debuffTimer;
            player.jumpVelocity /= (debuffTimer / 2);
            yield return new WaitForSeconds(attackSpeed * debuffTimer);
            player.speed *= debuffTimer;
            player.jumpVelocity *= (debuffTimer / 2);

        }
        else
        {
            StartCoroutine(player.cantMove(player.moveTime));
            yield return new WaitForSeconds(attackSpeed);
        }
        attackHitBox.SetActive(false);
        rangeAttackHitBox.SetActive(false);
        isAttacking = false;
        debuffTimer = 0f;
    }
}
