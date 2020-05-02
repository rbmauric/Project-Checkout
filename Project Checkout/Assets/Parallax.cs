using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam;
    public float parallaxEffect;

    private float length, startPos;
    public static bool canPar = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canPar)
        {
            float distance = (cam.transform.position.x) * parallaxEffect;
            transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        }
    }
}
