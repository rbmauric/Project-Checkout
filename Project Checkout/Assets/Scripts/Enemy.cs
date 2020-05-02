using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    public Text moneyGained;

    public int attackDamage = 40;
    public bool dead = false;
    public bool pushed = false;
    public float deathTime = 0.2f;
    public float slowDown = 0.9f;
    public float slowTime = 0.5f;
    public float pushForce = 30f;

    private Rigidbody2D erb;
    private bool beingPushed = false;
    private bool enemyDied;
    private EnemyAI eai;
    private RangedEnemyAI rai;

    // Start is called before the first frame update
    void Start()
    {
        erb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        if (pushed)
        {
            erb.velocity = erb.velocity * slowDown;

            if (!beingPushed)
                StartCoroutine(enemyPushed());
        }

        if (!dead && enemyDied)
        {
            //moneyGained.text = "+100";
            //moneyGained.color = Color.green;
            StartCoroutine(Die());
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !dead)
        {
            if (gameObject.tag == "Enemy")
            {
                FindObjectOfType<SoundManager>().Stop("Melee Move");
            }
            else if (gameObject.tag == "RangedEnemy")
            {
                FindObjectOfType<SoundManager>().Stop("Range Move");
            }
           
            enemyDied = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerAttack" && gameObject.name != "Hitbox" && other.GetComponentInParent<PlayerCombat>().isAttacking)
        {
            Debug.Log("Player Hit Enemy");
            Rigidbody2D erb = GetComponent<Rigidbody2D>();

            if (gameObject.tag == "Enemy")
            {
                FindObjectOfType<SoundManager>().Play("Enemy Hit");
                eai = GetComponent<EnemyAI>();
            }
            else if (gameObject.tag == "RangedEnemy")
            {
                FindObjectOfType<SoundManager>().Play("Range Enemy Hit");
                rai = GetComponent<RangedEnemyAI>();
            }

            pushed = true;

            if (other.transform.position.x < transform.position.x)
            {
                erb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
            }
            if (other.transform.position.x > transform.position.x)
            {
                erb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
            }

            if (other.name == "Range Attack Hitbox" || other.name == "Range Attack Hitbox2")
            {
                takeDamage(other.GetComponentInParent<PlayerCombat>().rangeAttackDamage);

                if (gameObject.tag == "Enemy")
                {
                    eai.enabled = false;
                }
                else if (gameObject.tag == "RangedEnemy")
                {
                    rai.enabled = false;
                }
                Debug.Log("Hit by " + other.name);

                GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
                StartCoroutine(enemyPushed());
                return;
            }
      
            takeDamage(other.GetComponentInParent<PlayerCombat>().attackDamage);
            if (gameObject.tag == "Enemy")
            {
                eai.enabled = false;
            }
            else if (gameObject.tag == "RangedEnemy")
            {
                rai.enabled = false;
            }
            Debug.Log("Hit by " + other.name);

            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
            StartCoroutine(enemyPushed());
        }

        else if (other.tag == "PlayerProjectile")
        {
            Debug.Log("Player hit Enemy with projectile");
            takeDamage(other.GetComponent<Projectile>().projDamage);
            
            Destroy(other.gameObject);

            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
            StartCoroutine(enemyPushed());
        }
    }

    IEnumerator Die()
    {
        Debug.Log("Enemy died!");
        dead = true;
        //StartCoroutine(moneyGain());

        if (gameObject.tag == "Enemy")
        {
            EnemyManager.aliveEnemies--;
            EnemyManager.spawnerActive = false;
        }
        else if (gameObject.tag == "RangedEnemy")
        {
            RangeEnemyManager.aliveEnemies--;
            RangeEnemyManager.spawnerActive = false;
        }
        yield return new WaitForSeconds(deathTime);
        PlayerStats.money += 100;
        Destroy(gameObject);
    }

    IEnumerator enemyPushed()
    {
        beingPushed = true;
        yield return new WaitForSeconds(slowTime);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

        if (gameObject.tag == "Enemy")
        {
            GetComponent<EnemyAI>().enabled = true;
        }
        else if (gameObject.tag == "RangedEnemy")
        {
            GetComponent<RangedEnemyAI>().enabled = true;
        }
       
        erb.velocity = Vector2.zero;
        pushed = false;
        beingPushed = false;
    }

    //IEnumerator moneyGain()
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    moneyGained.text = "";
    //}
}

