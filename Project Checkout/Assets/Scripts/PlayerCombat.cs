using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator animator;
    public EffectsControl rangeAttackEffect;
    public EffectsControl rangeAttackSSEffect;
    public GameObject attackHitBox;    
    public GameObject rangeAttackHitBox;
    public GameObject rangeAttackHitBox2;

    public int attackDamage = 40;
    public int halfDamage = 20;
    public int rangeAttackDamage = 70;
    public float attackActive = 0.7f;
    public float attackSpeed = 0.7f;
    public float startUp = 0.2f;
    private float debuffTimer = 0;

    public static bool doubleAttack = false;
    public static bool rangeAttack = false;
    public static bool projectileAttack = false;
    public bool isAttacking = false;

    private int projectileNum = 3;

    private void Start()
    {
        attackHitBox.SetActive(false);
        rangeAttackHitBox.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Primary Attack
        if (Input.GetButtonDown("Fire1") && !isAttacking && GetComponent<PlayerMovement>().groundCheck)
        {
            animator.SetFloat("Speed", 0);
            isAttacking = true;
            StartCoroutine(Attack());
        }

        //Projectile Attack
        if (Input.GetButtonDown("Fire2") && !isAttacking && GetComponent<PlayerMovement>().groundCheck && projectileAttack == true)
        {
            animator.SetFloat("Speed", 0);
            isAttacking = true;
            StartCoroutine(projectile());
        }
    }

    IEnumerator Attack()
    {
        //Stop Player Movement
        PlayerMovement player = GetComponent<PlayerMovement>();
        player.canMove = false;

        //Set Powerups
        if (rangeAttack == true)
        {
            debuffTimer++;
        }
        if (doubleAttack == true)
        {
            attackDamage = 70;
            rangeAttackDamage = 30;
            GetComponent<ProjectileManager>().proj.projDamage = 30;
            debuffTimer++;
        }

        //Debuff player depending on amount of powerups
        if (debuffTimer > 1)
        {
            animator.speed = 1 / (debuffTimer - 0.5f);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(startUp * debuffTimer);
            attackHitBox.SetActive(true);
            if (rangeAttack == true)
            {
                rangeAttackHitBox.SetActive(true);
                rangeAttackHitBox2.SetActive(true);
                StartCoroutine(rangeAttackEffect.fadeIn());
                StartCoroutine(rangeAttackSSEffect.fadeIn());
            }

            StartCoroutine(player.cantMove(player.moveTime * debuffTimer));
            player.speed /= debuffTimer;
            player.jumpVelocity /= (debuffTimer);

            yield return new WaitForSeconds(0.1f);
            attackHitBox.SetActive(false);
            if (rangeAttack == true)
            {
                StartCoroutine(rangeAttackEffect.fadeOut());
                StartCoroutine(rangeAttackSSEffect.fadeOut());
                rangeAttackHitBox.SetActive(false);
                rangeAttackHitBox2.SetActive(false);
            }

            yield return new WaitForSeconds(attackActive * debuffTimer);

            player.speed *= debuffTimer;
            player.jumpVelocity *= (debuffTimer);
        }
        else
        {
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(startUp);

            attackHitBox.SetActive(true);
            if (rangeAttack == true)
            {
                StartCoroutine(rangeAttackEffect.fadeIn());
                StartCoroutine(rangeAttackSSEffect.fadeIn());
                rangeAttackHitBox.SetActive(true);
                rangeAttackHitBox2.SetActive(true);

                yield return new WaitForSeconds(attackActive);
                StartCoroutine(rangeAttackEffect.fadeOut());
                StartCoroutine(rangeAttackSSEffect.fadeOut());
                rangeAttackHitBox2.SetActive(false);
                rangeAttackHitBox.SetActive(false);
            }
            yield return new WaitForSeconds(attackActive);
            attackHitBox.SetActive(false);           
            StartCoroutine(player.cantMove(player.moveTime));            
        }

        //Limit Player Attack Speed
        yield return new WaitForSeconds(attackSpeed);
        animator.speed = 1;
        isAttacking = false;
        debuffTimer = 0f;
    }

    IEnumerator projectile()
    {
        if (projectileNum == 0)
        {
            projectileAttack = false;
            projectileNum = 3;
        }

        //Stop Player Movement
        PlayerMovement player = GetComponent<PlayerMovement>();
        player.canMove = false;

        //Set Powerups
        if (rangeAttack == true)
        {
            debuffTimer++;
        }
        if (doubleAttack == true)
        {
            attackDamage = 70;
            rangeAttackDamage = 30;
            GetComponent<ProjectileManager>().proj.projDamage = 30;
            debuffTimer++;
        }

        if (debuffTimer > 1)
        {
            animator.speed = 1 / (debuffTimer - 0.5f);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(startUp * debuffTimer);
            GetComponent<ProjectileManager>().instantiateProjectile();

            StartCoroutine(player.cantMove(player.moveTime * debuffTimer));
            player.speed /= debuffTimer;
            player.jumpVelocity /= (debuffTimer);

            yield return new WaitForSeconds(attackActive * debuffTimer);

            player.speed *= debuffTimer;
            player.jumpVelocity *= (debuffTimer);
        }
        else
        {
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(startUp);

            GetComponent<ProjectileManager>().instantiateProjectile();
            StartCoroutine(player.cantMove(player.moveTime));
        }

        //Limit Player Attack Speed
        yield return new WaitForSeconds(attackSpeed);
        --projectileNum;
        animator.speed = 1;
        isAttacking = false;
        debuffTimer = 0f;
    }

    public static void resetPowerups()
    {
        doubleAttack = false;
        rangeAttack = false;
        projectileAttack = false;
    }
}
