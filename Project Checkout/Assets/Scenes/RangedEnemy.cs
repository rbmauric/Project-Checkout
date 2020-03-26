using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{

    public GameObject Projectile;
    public Transform GroundCheck;
    public float timeBetweenAttacks = 1.5f;

    [HideInInspector]
    public BoxCollider2D ranged;

   // Player playerRB;

    bool playerInRange;
    float timer;
    GameObject player;
  //  Player player;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ranged = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange != false)
        {
            Shoot();
        }
        //---------------------------------------
 /*       if(playerRB < ranged)
        {
            Shoot();
        }
        */

    }

    void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider enemy)
    {
        if (enemy.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Shoot()
    {
        timer = 0f;
        Instantiate(Projectile, GroundCheck);
    }
}
