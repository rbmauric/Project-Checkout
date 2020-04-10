using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHazard : MonoBehaviour
{
    public float tickRate = 0.7f;
    private bool ticked = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !ticked)
        {
            StartCoroutine(damageTick(other));
        }
    }

    IEnumerator damageTick(Collider2D other)
    {
        ticked = true;
        other.GetComponent<PlayerStats>().takeDamage(40);
        yield return new WaitForSeconds(tickRate);
        ticked = false;
    }
}
