using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public bool zoomOut;
    public bool zoomIn;
    public float zoomSpeed;
    public float camSize;

    private GameObject floor;
    private Camera mc;
    private float tmp;
    float timer;
    float startSize;
    float orig_y_scale;
    float orig_y_pos;
    private void Start()
    {
        mc = GameObject.Find("Main Camera").GetComponent<Camera>();
        startSize = GetComponent<Camera>().orthographicSize;
        floor = GameObject.Find("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomOut && !zoomIn) 
        {
            zoomingOut();
        }
        else if (zoomIn && !zoomOut)
        {
            zoomingIn();
        }
    }

    void zoomingOut()
    {
        float cursize = GetComponent<Camera>().orthographicSize;
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(cursize, camSize, Time.deltaTime * zoomSpeed);     
    }

    void zoomingIn()
    {
        float cursize = GetComponent<Camera>().orthographicSize;
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(cursize, startSize, Time.deltaTime * zoomSpeed);
    }
}
