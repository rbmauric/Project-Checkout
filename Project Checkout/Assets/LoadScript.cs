using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScript : MonoBehaviour
{
    public GameObject LoadingScreen; //The game object that represents the loading screen

    public Slider LoadingSlider;//The slider that is the slider in the loading screen

    public void LoadLevel(int scenenumber)//When level chosen, activate Coroutine function with int
    {
        StartCoroutine(LoadAsynchronously(scenenumber));
    }
    IEnumerator LoadAsynchronously (int scenenumber)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(scenenumber);// the object of AsyncOperation
        LoadingScreen.SetActive(true);//Turn the loading screen on
        while(Operation.isDone == false)//while the loading screen isn't done
        {
            float progress = Mathf.Clamp01(Operation.progress / .9f);
            LoadingSlider.value = progress;//slider will load until progress is equal to 1
            yield return null;
        }
    }
}
