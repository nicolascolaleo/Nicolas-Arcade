using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelScreenBlackout : MonoBehaviour
{
    SpriteRenderer sprite;
    public bool FadeOut;
    private void Awake() 
    {
        FadeOut = false;
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeInAndOut());
    }
    private void FixedUpdate() 
    {
        if(FadeOut == true)
        {
            FadeOut = false;
            StartCoroutine(FadeOutEffect());
        }
    }

    private IEnumerator FadeInAndOut()
    {
        yield return new WaitForSeconds(0.2f);
        do
        {
            sprite.color = new Color(255,255,255,sprite.color.a +0.3f * Time.fixedDeltaTime);
            yield return null;
        }
        while(sprite.color.a <=1f);
    }

    public IEnumerator FadeOutEffect()
    {
        yield return new WaitForSeconds(0.5f);
        do
        {
            sprite.color = new Color(255,255,255,sprite.color.a -0.2f * Time.fixedDeltaTime);
            yield return null;
        }
        while(sprite.color.a >=0f);
        Destroy(gameObject);
    }
}
