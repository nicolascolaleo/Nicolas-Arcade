using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBangScript : MonoBehaviour
{
    SpriteRenderer sprite;
    private void Awake() 
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOutEffect());
        Debug.Log("suppose to fade");
    }

    public IEnumerator FadeOutEffect()
    {
        yield return new WaitForSeconds(0.5f);
        do
        {
            sprite.color = new Color(255,255,255,sprite.color.a -0.4f * Time.fixedDeltaTime);
            yield return null;
        }
        while(sprite.color.a >=0f);
        Destroy(gameObject);
    }
}
