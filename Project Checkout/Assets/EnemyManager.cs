using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] enemySpawnPoints;
    public GameObject[] warningSprites;
    public GameObject[] walls;
    public GameObject cam;
    public GameObject main_cam;
    public Text moneyGain;

    public int numEnemies;
    public float spawnTime;
    public float resetTime;
    public float spawnLevel = 0.5f;
    
    public static int aliveEnemies = 0;

    private bool enemySpawned = false;
    private bool timeUp = false;
    public static bool spawnerActive = true;
    private List<Enemy> enemy;
    private bool enemiesDead = false;

    private void Update()
    {
        if (enemySpawned && !spawnerActive && numEnemies > 0)
        {
            Debug.Log("Issue here");
            StartCoroutine(spawnTimer());
        }

        if (aliveEnemies <= 0 && numEnemies <= 0 && !enemiesDead)
        {
            cam.GetComponent<CameraZoom>().zoomOut = false;
            cam.GetComponent<CameraZoom>().zoomIn = true;
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].SetActive(false);
            }

            enemiesDead = true;
            StartCoroutine(cameraReset());
            spawnerActive = true;
            enemySpawned = false;
        }
        //if (enemy.GetComponent<Enemy>().dead)
        //{
        //    spawnerActive = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Test");

        if (other.tag == "Player" && !enemySpawned && numEnemies > 0)
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].SetActive(true);
            }

            Debug.Log("Changing Camera");

            main_cam.SetActive(false);
            cam.SetActive(true);
            cam.GetComponent<CameraZoom>().zoomOut = true;
            Parallax.canPar = false;

            Debug.Log("Enemies spawned");
            enemySpawned = true;
            spawnerActive = false;
        }           
            //If enemy not killed in certain time, spawwn enemy
    }

    public GameObject enemySpawn()
    {
        int spawnLoc = numEnemies % 2;
        GameObject origEnem = Instantiate(enemyPrefab);
        aliveEnemies++;

        origEnem.transform.position = enemySpawnPoints[spawnLoc].position;

        if (origEnem.tag == "Enemy")
        {
            origEnem.GetComponent<EnemyAI>().chaseRange = 100;
        }
        else if (origEnem.tag == "RangedEnemy")
        {
            origEnem.GetComponent<RangedEnemyAI>().attackRange = 100;
        }
        origEnem.GetComponent<Enemy>().pushForce = 70;
        numEnemies--;

        return origEnem;
    }

    IEnumerator spawnTimer()
    {
        spawnerActive = true;

        int spawnLoc = numEnemies % 2;
        warningSprites[spawnLoc].SetActive(true);
        EffectsControl ec = warningSprites[spawnLoc].GetComponent<EffectsControl>();
        StartCoroutine(ec.fadeIn());

        yield return new WaitForSeconds(1);
        warningSprites[spawnLoc].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        //StartCoroutine(warningSprites[spawnLoc].GetComponent<EffectsControl>().fadeIn());
        warningSprites[spawnLoc].SetActive(false);
        enemySpawn(); 
       
        //yield return new WaitForSeconds(nextSpawn);
        //spawnerActive = false;
    }

    IEnumerator cameraReset()
    {
        Parallax.canPar = true;
        cam.GetComponent<CameraZoom>().zoomOut = false;
        cam.GetComponent<CameraZoom>().zoomIn = true;
        yield return new WaitForSeconds(resetTime);
        cam.SetActive(false);
        main_cam.SetActive(true);
    }
 }
