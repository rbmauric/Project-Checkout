using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] pts;
    public Transform currentPt;
    public Transform target;
    public GameObject attackHitbox;
    public GameObject detectionBox;

    public float chaseRange = 2;
    public float attackRange = 1;
    public float speed;
    public int index;

    public float attackDelay = 0.7f;
    public float cooldownTime = 2.5f;
    public float chargeTime = 0.4f;
    public float soundLoop = 10f;

    private Animator animator;

    private bool patrolling = false;
    private bool chasing = false;
    private bool attacking = false;
    private bool wait = false;

    private bool right = true;
    private bool flippable = true;
    private bool attackStart = false;

    private bool soundActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (pts.Length == 0)
        {
            FindObjectOfType<SoundManager>().Play("Melee Move");
            GameObject player = GameObject.Find("Player");
            target = player.transform;
            animator = GetComponent<Animator>();
            return;
        }

        index = Random.Range(0, pts.Length);
        currentPt = pts[index];

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Enemy>().dead)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            //Debug.Log("Distance to target = " + distanceToTarget);

            //Out of Chase Range
            if (distanceToTarget > chaseRange && chasing && !wait)
            {
                wait = true;
                Debug.Log("Stopped Chasing");
                FindObjectOfType<SoundManager>().Stop("Melee Move");
                float randomTime = Random.Range(0.25f, 1f);
                StartCoroutine(enemyWait(randomTime));
            }

            //Flipping Enemy Depending on Player Location
            if (target.position.x < transform.position.x && right)
            {
                flip();
            }
            if (target.position.x > transform.position.x && !right)
            {
                flip();
            }

            //Different States; Patrolling, Chasing, Attacking
            if (distanceToTarget > chaseRange && !chasing)
            {
                animator.SetFloat("Speed", speed);

                enemyPatrol();
                //Debug.Log("Patrolling");
            }

            if (distanceToTarget < chaseRange && distanceToTarget > attackRange && !attackStart)
            {
                animator.SetFloat("Speed", speed);
                enemyChase();
                //Debug.Log("Chasing");
            }
            if (distanceToTarget < chaseRange && distanceToTarget > attackRange && !attackStart)
            {
                animator.SetFloat("Speed", speed);
                enemyChase();
                //Debug.Log("Chasing");
            }

            if (distanceToTarget < attackRange && !attacking)
            {
                attacking = true;
                StartCoroutine(enemyAttack());
                //Debug.Log("Attacking");
            }
        }
    }

    

    void enemyPatrol()
    {
        float randomTime = Random.Range(0.2f, 1.5f);
        float randomSpeed = Random.Range(speed / 2, speed);

        Vector3 targetPos = new Vector3(currentPt.position.x, transform.position.y, currentPt.position.z);

        if (targetPos.x > transform.position.x && !right)
        {
            flip();
        }

        if (!soundActive)
        {
            FindObjectOfType<SoundManager>().Play("Melee Move");
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);

        if (transform.position.x == currentPt.position.x)
        {
            //Debug.Log("Position Met");
            animator.SetFloat("Speed", 0);

            if (!patrolling && !chasing)
                StartCoroutine(enemyWait(randomTime));
        }

    }

    void enemyChase()
    {
        chasing = true;
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
    }

    IEnumerator enemyAttack()
    {
        flippable = false;
        attacking = true;
        soundActive = false;

        //Charge Up
        yield return new WaitForSeconds(chargeTime);

        //Attack Active
        animator.SetTrigger("Attack");
        FindObjectOfType<SoundManager>().Play("Melee Attack");
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(attackDelay);

        //Cooldown
        attackHitbox.SetActive(false);
        yield return new WaitForSeconds(cooldownTime);
        attacking = false;
        attackStart = false;
        flippable = true;
        soundActive = true;
        
    }

    IEnumerator enemyWait(float randomTime)
    {
        patrolling = true;
        animator.SetFloat("Speed", 0);

        FindObjectOfType<SoundManager>().Stop("Melee Move");

        yield return new WaitForSeconds(randomTime);
        //Debug.Log("Continuing patrol");
        if (pts.Length > 0)
        {
            index = Random.Range(0, pts.Length);
            currentPt = pts[index];
        }

        patrolling = false;
        chasing = false;
        wait = false;
        attacking = false;
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

    IEnumerator playSound(string name)
    {
        soundActive = true;
        FindObjectOfType<SoundManager>().Play("Melee Move");
        yield return new WaitForSeconds(3);
        soundActive = false;
    }
}
