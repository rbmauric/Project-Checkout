using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public float pushForce = 30f;
    private bool canAttack = false;

    private void OnTriggerStau2D(Collider2D other)
    {
        if (canAttack)
            return;

        Debug.Log("Attacking");

        canAttack = true;

        if (other.tag == "Enemy")
        {
            PlayerCombat pc = GetComponentInParent<PlayerCombat>();
            Rigidbody2D prb = GetComponentInParent<Rigidbody2D>();
            Rigidbody2D erb = other.GetComponentInParent<Rigidbody2D>();
            Enemy en = other.GetComponentInParent<Enemy>();
            
            en.pushed = true;
       
            if (other.transform.position.x > transform.position.x && !en.dead)
            {
                Debug.Log("Pushing enemy left");
                erb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
            }
            else if (other.transform.position.x < transform.position.x && !en.dead)
            {
                Debug.Log("Pushing  right");
                prb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
            }

            if (gameObject.name == "Range Attack Hitbox")
            {

                if (other.transform.position.x > transform.position.x && !en.dead)
                {
                    Debug.Log("Pushing player left");
                    erb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
                }
                else if (other.transform.position.x < transform.position.x && !en.dead)
                {
                    Debug.Log("Pushing player right");
                    prb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
                }

                if (canAttack)
                { 
                    StartCoroutine(cooldown());
                    other.GetComponent<Enemy>().takeDamage(pc.rangeAttackDamage);

                    Debug.Log("Hit by Range Attack");

                }
                return;
            }

            if (canAttack)
            {
                other.GetComponent<Enemy>().takeDamage(pc.attackDamage);
                StartCoroutine(cooldown());
                Debug.Log("Hit by Regular Attack");
            }
        }

        if (other.tag == "Player")
        {
            Enemy en = GetComponentInParent<Enemy>();

            Debug.Log("Enemy Hit");
            //other.GetComponent<PlayerStats>().takeDamage(en.attackDamage);
            Rigidbody2D prb = other.GetComponent<Rigidbody2D>();
            PlayerStats player = other.GetComponent<PlayerStats>();

            if (other.transform.position.x < transform.position.x)
            {
                prb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
            }
            if (other.transform.position.x > transform.position.x)
            {
                prb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
            }
        }
        
    }

    IEnumerator cooldown()
    {
        yield return new WaitForEndOfFrame();
        canAttack = false;
    }
}
