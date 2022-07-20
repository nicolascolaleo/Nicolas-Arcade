using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaNameFadeEffect : MonoBehaviour
{
    SpriteRenderer sprite;
    private GameObject cameraPos;
    private bool playOnce;

    private void Awake() 
    {
        playOnce = true;
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera");
        sprite = GetComponent<SpriteRenderer>();
        //Debug.Log(cameraPos.transform.position.x);
    }
    private void Update() 
    {
        if(cameraPos.transform.position.x >= 10.2f
            && playOnce == true)
            {
                //Debug.Log("work?");
                playOnce = false;
                StartCoroutine(FadeInAndOut());
            }
    }

    private IEnumerator FadeInAndOut()
    {
       // Debug.Log("ok");
        yield return new WaitForSeconds(1.25f);
        do
        {
            sprite.color = new Color(255,255,255,sprite.color.a +0.45f * Time.fixedDeltaTime);
            yield return null;
        }
        while(sprite.color.a <=1f);

        yield return new WaitForSeconds(1.35f);

        do
        {
            sprite.color = new Color(255,255,255,sprite.color.a -1.2f * Time.fixedDeltaTime);
            yield return null;
        }
        while(sprite.color.a >= 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
