using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public List<string> items;
    public GameObject[] healthIcons;

    public static float money = 500;
    public static int itemCount = 0;
    public int maxHealth = 100;
    public int currentHealth;
    public int numLives = 3;
    public int healthNum;

    public float pushForce = 30f;
    public float playerHurtTime = 0.2f;
    // public HealthBar healthBar;

    public Transform spawnPos;
    public float respawnTime = 3;
    public bool dead = false;

    public SoundManager sm;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthNum = 2;
        for (int i = 0; i < healthNum; i++)
        {
            healthIcons[i].SetActive(true);
        }

        //healthBar.SetMaxHealth(maxHealth);
        //Setting the Player health to max
    }

    private void Update()
    {
        if (itemCount == 2)
        {
            GameManager.levelComplete();
        }
        else if (healthNum == 0)
        {
            StartCoroutine(playerDied());
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        //healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyAttack")
        {
            Enemy en = other.GetComponentInParent<Enemy>();

            Debug.Log("Enemy Hit the Player");
            takeDamage(en.attackDamage);

            if (other.transform.position.x > transform.position.x)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
            }
            if (other.transform.position.x < transform.position.x)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);
            }

            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
            StartCoroutine(playerHurt());

            healthNum--;
            healthIcons[healthNum].SetActive(false);
        }
        if (other.tag == "EnemyProjectile")
        {
            takeDamage(other.GetComponent<RangedEnemyProjectile>().projDamage);
            Destroy(other.gameObject);
            if (currentHealth % 2 == 0)
            {
                --healthNum;
                healthIcons[healthNum].SetActive(false);
            }

            StartCoroutine(playerHurt());
        }
    }

    IEnumerator playerHurt()
    {
        sm.Play("Player Hit");
        yield return new WaitForSeconds(playerHurtTime);
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }

    IEnumerator playerDied()
    {
        yield return new WaitForSeconds(playerHurtTime);
        GameManager.gameOver();
    }
}
