using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject healthBarPrefab;
    public PlayerStats mainPlayer;
    public Transform spawnPos;

    public float respawnTime = 3;

    private void Update()
    {
        if (mainPlayer.dead)
        {
            mainPlayer = playerPrefab.GetComponent<PlayerStats>();
            mainPlayer.healthBar = healthBarPrefab.GetComponentInChildren<HealthBar>();
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(playerPrefab, spawnPos.position, spawnPos.rotation);
    }


}
