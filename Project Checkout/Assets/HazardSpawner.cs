using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject hazard;
    public Transform spawner;
    public float spawnTime = 1.3f;
    public float spawnPoint = 10.0f;
    public bool spawned = false;
    private Vector2 spawnPosition;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !spawned)
        {
            StartCoroutine(SpawnHazard());
        }
    }
    IEnumerator SpawnHazard()
    {
        spawned = true;
        spawnPosition.x = Random.Range(spawner.position.x - spawnPoint, spawner.position.x + spawnPoint);
        spawnPosition.y = spawner.position.y;
        Instantiate(hazard, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        spawned = false;
    }
    
}
