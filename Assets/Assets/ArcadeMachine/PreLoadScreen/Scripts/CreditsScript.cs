using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
public Renderer Renderer;
    public Color Color;

    private void Awake()
    {
        Renderer = gameObject.GetComponent<Renderer>();
        Renderer.material.color = Color; 
        StartCoroutine(FadeInAndOutEffect());
    }


    private IEnumerator FadeInAndOutEffect()
    {
        Debug.Log("started");
        do
        {
            Color.a += 0.25f * Time.fixedDeltaTime;
            Renderer.material.color = Color;
            yield return null;
        }
        while(Color.a <= 1f);
        yield return new WaitForSeconds(1.0f);
                do
        {
            Color.a -= 0.35f * Time.fixedDeltaTime;
            Renderer.material.color = Color;
            yield return null;
        }
        while(Color.a >= 0f);
        SceneManager.LoadScene("LoadingScene");

    }
}
