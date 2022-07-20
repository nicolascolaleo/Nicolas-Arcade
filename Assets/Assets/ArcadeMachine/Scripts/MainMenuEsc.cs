using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEsc : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadNextScene();
        }
    }
        public void LoadNextScene()
    {
        SceneManager.LoadScene("LoadingScene"); 
    }

    private IEnumerator IntroFinished()
    {
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<ReloadEffects>().SceneNumber = 4;
        gameObject.GetComponent<ReloadEffects>().CallLoadEffect();
    }

    public void LoadGameAfterIntroEnd()
    {
        StartCoroutine(IntroFinished());
    }

    public void LoadGameAfterSkip()
    {
        gameObject.GetComponent<ReloadEffects>().SceneNumber = 4;
        gameObject.GetComponent<ReloadEffects>().CallLoadEffect();
    }
}  
