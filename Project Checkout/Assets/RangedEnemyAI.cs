using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : MonoBehaviour
{
    public Transform[] pts;
    public Transform currentPt;
    public Transform target;

    public GameObject detection;
    public GameObject projectile;
    public Transform shootingPoint;
    public float projSpeed;

    public int index;

    public float speed = 2f;
    public float attackRange = 5f;
    public float waitTime = 1f;
    public float cooldown = 1f;
    public float chargeUp = 0.3f;

    private bool patrolling = false;
    private bool attacking = false;
    private bool flippable = true;
    private bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;

        if (pts.Length == 0)
        {
            GameObject player = GameObject.Find("Player");
            target = player.transform;
            FindObjectOfType<SoundManager>().Play("Range Move");

            return;
        }
        else
        {
            currentPt = pts[index];
            GameObject player = GameObject.Find("Player");
            FindObjectOfType<SoundManager>().Play("Range Move");
            target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        //Flipping Enemy
        if (target.position.x < transform.position.x && right)
        {
            flip();
        }
        if (target.position.x > transform.position.x && !right)
        {
            flip();
        }

        //Patrolling
        if (distanceToTarget > attackRange && !patrolling && !attacking)
            rangedEnemyPatrol();

        //Attacking
        if (distanceToTarget < attackRange && !attacking)
        {
            StartCoroutine(rangedEnemyAttack());
        }

    }

    void rangedEnemyPatrol()
    {
        float randomWaitTime = Random.Range(0.5f, waitTime);
        float randomSpeed = Random.Range(1f, speed);

        Vector3 targetPos = new Vector3(currentPt.position.x, transform.position.y, currentPt.position.z);
        if (targetPos.x < transform.position.x && right)
        {
            flip();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * randomSpeed);

        if (transform.position.x == currentPt.position.x)
        {
            StartCoroutine(rangedEnemyWait(waitTime));
        }
    }

    IEnumerator rangedEnemyAttack()
    {
        attacking = true;
        flippable = false;

        //Charge Up
        detection.SetActive(true);
        yield return new WaitForSeconds(chargeUp);

        //Attack
        detection.SetActive(false);
        FindObjectOfType<SoundManager>().Play("Range Attack");
        GameObject proj = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
        if (right)
        {
            proj.GetComponent<RangedEnemyProjectile>().right = true;
        }
        else
        {
            proj.GetComponent<RangedEnemyProjectile>().right = false;
        }

        //Cooldown
        yield return new WaitForSeconds(cooldown);
        attacking = false;
        flippable = true;
    }

    IEnumerator rangedEnemyWait(float waitTime)
    {
        Debug.Log("Ranged Enemy Waiting");
        patrolling = true;
        
        yield return new WaitForSeconds(waitTime);

        randomIndex();
        patrolling = false;
    }

    void randomIndex()
    {
        index = Random.Range(0, pts.Length);
        Debug.Log("Random Index: " + index);
        currentPt = pts[index];
    }

    void flip()
    {
        if (flippable)
        {
            Canvas c = GetComponentInChildren<Canvas>();
            Vector3 origin = c.transform.localScale;

            right = !right;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            origin.x *= -1;
            transform.localScale = scale;

            c.transform.localScale = origin;
        }
    }
}
