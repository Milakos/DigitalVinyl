using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    CanvasGroup canvasGroup;

    
    private void Start() 
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeOut(3));
    }

    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(1);
        StartCoroutine(FadeIn(3));
    }

    public void OnApplicationQuit() 
    {
        Application.Quit();    
    }

    

 
        public IEnumerator FadeOut(float time)
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                print("fadeOut");
                yield return null;
            }

        }
        public IEnumerator FadeIn(float time)
        {
            
            while(canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                print("fadeIn");
                yield return null;
            }
        }
}
