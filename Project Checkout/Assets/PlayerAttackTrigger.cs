//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerAttackTrigger : MonoBehaviour
//{
//    public float pushForce = 30f;
//    private bool canAttack = false;
//    public float cooldownTime;

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (canAttack)
//            return;

//        Debug.Log("Attacking");

//        canAttack = true;

//        if (other.tag == "Enemy")
//        {
//            PlayerCombat pc = GetComponentInParent<PlayerCombat>();
//            Rigidbody2D prb = GetComponentInParent<Rigidbody2D>();
//            Rigidbody2D erb = other.GetComponentInParent<Rigidbody2D>();
//            Enemy en = other.GetComponentInParent<Enemy>();

//            if (gameObject.name == "Range Attack Hitbox")
//            {
//                rangeAttack(other, erb, en);
//            }
//            else
//            {
//                regularAttack(other, erb, en);
//            }
//        }
//    }

//    public void regularAttack(Collider2D other, Rigidbody2D erb, Enemy en)
//    {
//        en.pushed = true;

//        if (other.transform.position.x > transform.position.x && !en.dead)
//        {
//            Debug.Log("Pushing enemy right");
//            erb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
//        }
//        else if (other.transform.position.x < transform.position.x && !en.dead)
//        {
//            Debug.Log("Pushing enemy left");
//            erb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
//        }

//        if (canAttack)
//        {
//            other.GetComponent<Enemy>().takeDamage(GetComponentInParent<PlayerCombat>().attackDamage);
//            StartCoroutine(cooldown());
//            Debug.Log("Hit by Regular Attack");
//        }
//    }

//    public void rangeAttack(Collider2D other, Rigidbody2D erb, Enemy en)
//    {
//        if (other.transform.position.x > transform.position.x && !en.dead)
//        {
//            Debug.Log("Pushing player left");
//            erb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
//        }
//        else if (other.transform.position.x < transform.position.x && !en.dead)
//        {
//            Debug.Log("Pushing player right");
//            erb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
//        }

//        if (canAttack)
//        {
//            StartCoroutine(cooldown());
//            other.GetComponent<Enemy>().takeDamage(GetComponentInParent<PlayerCombat>().rangeAttackDamage);

//            Debug.Log("Hit by Range Attack");

//        }
//        return;
//    }


//    IEnumerator cooldown()
//    {
//        yield return new WaitForEndOfFrame();
//        canAttack = false;
//    }
//}
