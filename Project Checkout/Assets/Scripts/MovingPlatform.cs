using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   
    public GameObject surface;//surface/groundobject

    public float speed;//how fast the platform is going from point to point

    public Transform currentpt;//position that the platform is moving towards

    public Transform[] pts;//array of points the platform can move to

    public int ptselector;//index of pts
    // Start is called before the first frame update
    void Start()
    {
        currentpt = pts[ptselector];//set to where platform is moving to by ptselector
    }

    // Update is called once per frame
    void Update()
    {
        surface.transform.position = Vector3.MoveTowards(surface.transform.position, currentpt.position, Time.deltaTime*speed);//move the surface by moving towards currentpt's position at rate of Time.deltaTime*speed
        if(surface.transform.position == currentpt.position)
        {
            Debug.Log("Point Found");
            ptselector++;
            if(ptselector == pts.Length)
            {
                ptselector = 0;
            }
            currentpt = pts[ptselector];
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.collider.transform.SetParent(null);
    }
}
