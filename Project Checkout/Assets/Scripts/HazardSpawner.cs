using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject hazard;
    public float spawnTime = 1.3f;
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
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        Vector2 minBounds = col.bounds.min;
        Vector2 maxBounds = col.bounds.max;

        spawned = true;
        spawnPosition.x = Random.Range(minBounds.x + 0.15f, maxBounds.x - 0.15f);
        spawnPosition.y = transform.position.y - 0.15f;
        Instantiate(hazard, spawnPosition, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        spawned = false;
    }
    
}
