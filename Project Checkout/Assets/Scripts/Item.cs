using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Item!");
            other.GetComponentInParent<PlayerStats>().items.Add(gameObject.name);
            FindObjectOfType<SoundManager>().Play("Item Pickup");
            PlayerStats.itemCount++;
            Destroy(gameObject);
        }
    }
}
