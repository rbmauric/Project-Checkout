using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    public GameObject go;//the object to spawn
    public bool stopper = false;//to make the spawner stop spawning
    public float timer;//how long it takes an object to spawn
    public float cooldown;//how long before the next object spawns
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObj", timer, cooldown);
    }

    public void spawnObj()
    {
        Instantiate(go, transform.position, transform.rotation);
        if(stopper)
        {
            CancelInvoke("spawnObj");
        }
    }
}
