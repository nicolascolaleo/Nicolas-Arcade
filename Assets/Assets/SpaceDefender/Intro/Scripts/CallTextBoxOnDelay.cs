using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallTextBoxOnDelay : MonoBehaviour
{
    public GameObject firstScene, secondScene, TextBox, SecondTextBox, screenFade;
    public bool isFirstSceneOver, isSecondSceneOver;
    void Start()
    {
        Instantiate(firstScene, transform.position, transform.rotation, gameObject.transform);
        isFirstSceneOver = false;
        isSecondSceneOver = false;
        StartCoroutine(waitForSeconds());
    }
    private void Update() 
    {
        if(isFirstSceneOver == true)
        {
            isFirstSceneOver = false;
            Instantiate(screenFade, transform.position, transform.rotation, gameObject.transform);
            StartCoroutine(screenFadeOut());
        }
        else if(isSecondSceneOver == true)
        {
            isSecondSceneOver = false;
            Instantiate(screenFade, transform.position, transform.rotation, gameObject.transform);
            FindObjectOfType<MainMenuEsc>().LoadGameAfterIntroEnd();
        }
    }

    IEnumerator waitForSeconds()
    {
        yield return new WaitForSeconds(2.5f);
        Instantiate(TextBox, new Vector2(transform.position.x, transform.position.y + 3.5f), transform.rotation);
    }

    IEnumerator screenFadeOut()
    {
        yield return new WaitForSeconds(3.3f);
        Destroy (GetComponent<Transform>().GetChild(0).gameObject);
        yield return new WaitForSeconds(0.2f);
        GameObject.FindObjectOfType<EndLevelScreenBlackout>().FadeOut = true;
        Instantiate(secondScene, transform.position, transform.rotation, gameObject.transform);
        yield return new WaitForSeconds(3.2f);
        Instantiate(SecondTextBox, new Vector2(transform.position.x, transform.position.y + 3.5f), transform.rotation);
    }
}
