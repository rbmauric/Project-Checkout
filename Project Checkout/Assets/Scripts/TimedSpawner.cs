using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    public GameObject go;//the object to spawn
    public bool stopper = false;//to make the spawner stop spawning
    public float timer;//how long it takes an object to spawn
    public float offset;
    public float cooldown;//how long before the next object spawns

    private void Update()
    {
        if (!stopper)
        {
            StartCoroutine(timedSpawner());
        }
    }

    IEnumerator timedSpawner()
    {
        stopper = true;
        GameObject newgo = Instantiate(go, transform.position, transform.rotation);
        yield return new WaitForSeconds(timer + offset);
        
        Destroy(newgo);
        yield return new WaitForSeconds(cooldown + offset);
        stopper = false;
    }
}