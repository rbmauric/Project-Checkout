using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPos;
    private PlayerStats ps;

    public float respawnTime = 3f;

    private void Start()
    {
        ps = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (ps.dead)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        ps.dead = false;
        Debug.Log("DEAD");
        player.SetActive(false);
        ps.numLives--;

        yield return new WaitForSeconds(respawnTime);
        Debug.Log("RESPAWNED");
        ps.currentHealth = ps.maxHealth;
        //ps.healthBar.SetHealth(ps.currentHealth);
        player.transform.position = spawnPos.position;
        player.SetActive(true);
    }
}
