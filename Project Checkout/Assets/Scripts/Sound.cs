using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
   
    public AudioClip clip;
    
    [HideInInspector]
    public AudioSource source;

    public string name;
    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3)]
    public float pitch;

    public bool loop;
    

}
