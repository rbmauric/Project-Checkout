using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public float pushForce = 30f;
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Enemy en = GetComponentInParent<Enemy>();

    //        Debug.Log("Enemy Hit");
    //        other.GetComponentInParent<PlayerStats>().takeDamage(en.attackDamage);
    //        Rigidbody2D prb = other.GetComponent<Rigidbody2D>();
    //        PlayerStats player = other.GetComponentInParent<PlayerStats>();

    //        if (other.transform.position.x < transform.position.x)
    //        {
    //            prb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
    //        }
    //        if (other.transform.position.x > transform.position.x)
    //        {
    //            prb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
    //        }

    //        player.takeDamage(50);
    //        player.healthNum--;
    //        player.healthIcons[player.healthNum].SetActive(false);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("ENTER");
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("STAY");
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("EXIT");
    //    }
    //}
}
