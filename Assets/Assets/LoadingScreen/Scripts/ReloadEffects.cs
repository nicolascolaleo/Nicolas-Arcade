using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadEffects : MonoBehaviour
{
    private int randomTransition;
    public int SceneNumber;
    private float randomRotation, transitionTime;   
    public GameObject ClockEffect, CircleEffect, SnakeEffect, StripesEffect, AfterResetEffect, FlashbangEffect,
    FadeOutBlackPrefab;
    private void Awake() 
    {
        SimpleScreenTransition();
    }
    
    public void CallLoadEffect()
    {
        StartCoroutine(LoadLevel());
    }
    
    IEnumerator LoadLevel()
    {
        randomTransition = Random.Range(1,5);
        if(randomTransition == 1)
        {
            transitionTime = 1.6f;
            Instantiate(ClockEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(SceneNumber);
        }
        else if(randomTransition == 2)
        {
            transitionTime = 1.6f;
            Instantiate(CircleEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(SceneNumber);
        }
        else if(randomTransition == 3)
        {
            transitionTime = 1.8f;
            Instantiate(SnakeEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(SceneNumber);
        }
        else if(randomTransition == 4)
        {
            transitionTime = 1.6f;
            Instantiate(StripesEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(SceneNumber);
        }
        yield return null;
    }

    private void RandomRotation()
    {
        randomRotation = Random.Range(1, 5);
        {
            if(randomRotation == 1)
            {
                randomRotation = 0f;
            }
            else if(randomRotation == 2)
            {
                randomRotation = 90f;
            }
            else if(randomRotation == 3)
            {
                randomRotation = -90f;
            }
            else if(randomRotation == 4)
            {
                randomRotation = 180f;
            }
        }
    }
    public void SimpleScreenTransition()
    {
        RandomRotation();
        Instantiate(AfterResetEffect, transform.position,Quaternion.Euler(0f, 0f,randomRotation));
    }

    public void Flashbang()
    {
        Instantiate(FlashbangEffect, transform.position,transform.rotation);
    }
    public void FadeOutBlack()
    {
        Instantiate(FadeOutBlackPrefab, transform.position, transform.rotation);
    }

    public void JustLoadScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
