using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{

    public GameObject Projectile;
    public Transform GroundCheck;
    public float timeBetweenAttacks = 1.5f;
    float speed = 50;

    //   [HideInInspector]
    //  public BoxCollider2D ranged;

    // Player playerRB;

    public bool playerInRange;
    float timer;
    GameObject player;
  //  Player player;
    


    // Start is called before the first frame update
    void Start()
    {
        GroundCheck = GetComponent<Transform>();
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
 
        float minAttackDistance = 1.5f;
 
    }

    //-----------------------------------
    // This actually work
    /* public void RangeTrigger()
     {
         playerInRange = true;
     }

     public void OoBTrigger()
     {
         playerInRange = false;
     }
     */

    private void OnTriggerEnter2D(Collider2D attack)
    {

        if (attack.CompareTag("Player"))
        {
            playerInRange = true;
            Shoot();
        }
    }

    private void OnTriggerExit2D(Collider2D _OoB)
    {
        if (_OoB.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }



    public void Shoot()
    {
        if (playerInRange == true)
        {
            timer = 0f;
            Instantiate(Projectile, GroundCheck);
            Projectile.transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }

    }

}
