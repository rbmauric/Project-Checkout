using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsControl : MonoBehaviour
{
    public float fadeTime;
    public float targetAlpha;
    public float effectTime;

    public IEnumerator fadeIn()
    {
        Debug.Log("Fading in");

        Color color = GetComponent<SpriteRenderer>().color;
        float startA = color.a;
        float t = 0;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float blend = Mathf.Clamp01(t / fadeTime);
            color.a = Mathf.Lerp(startA, targetAlpha, blend);
            GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
    }

    public IEnumerator fadeOut()
    {
        Debug.Log("Fading out");

        Color color = GetComponent<SpriteRenderer>().color;
        float startA = color.a;
        float t = 0;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float blend = Mathf.Clamp01(t / fadeTime);
            color.a = Mathf.Lerp(startA, 0, blend);
            GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
    }
}
