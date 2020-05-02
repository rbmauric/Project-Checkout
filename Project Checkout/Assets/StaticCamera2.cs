using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCamera2 : MonoBehaviour
{
    public GameObject backgrounds;
    public Parallax[] par;

    public void parallaxOff()
    {
        par = backgrounds.GetComponentsInChildren<Parallax>();
        foreach (Parallax p in par)
        {
            p.enabled = false;
            Debug.Log("why isnt this working");
        }
    }

    public void parallaxReset()
    {
        foreach (Parallax p in par)
        {
            p.enabled = true;
        }
    }
}
