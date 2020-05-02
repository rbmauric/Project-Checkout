using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCamera : MonoBehaviour
{
    public void parallaxOff()
    {
        Parallax.canPar = false;
    }

    public void parallaxReset()
    {
        Parallax.canPar = true;
    }
}