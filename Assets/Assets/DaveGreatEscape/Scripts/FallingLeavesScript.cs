using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLeavesScript : MonoBehaviour
{
    private float fallingSpeed, whenToFade;
    public Renderer Renderer;
    public Color Color;
    private Animator anim;
 
    void Start()
    {
        anim = GetComponent<Animator>();
        GetRandomAnimation();
        Renderer = gameObject.GetComponent<Renderer>();
        Renderer.material.color = Color;
        fallingSpeed = RandomFallingSpeed();
       // Debug.Log("falling speed is " + fallingSpeed);
        whenToFade = RandomFadeOutPos();
       // Debug.Log("fading at y pos = " + whenToFade);
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        FallingEffect();
    }
    
    private void FallingEffect()
    {
        transform.position += new Vector3(0, fallingSpeed * Time.deltaTime);
        if(transform.position.y <= whenToFade)
        {
            FadeOut();
        }
    }

    private float RandomFallingSpeed()
    {
    if(Random.Range(0,2) == 1)
        {
            return -0.3f;
        }
            else
        {
            return -0.5f;
        }
    }
    private float RandomFadeOutPos()
    {
        float NewPos = Random.Range(0.2f, -0.6f);
        return NewPos;
    }
    private void FadeOut()
    {
        Color.a -= 0.15f * Time.fixedDeltaTime;
        Renderer.material.color = Color;
        if(Color.a <= 0f)
        {
            Destroy(gameObject);
        }
        else if(transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator FadeIn()
    {
        do
        {
            Color.a += 0.15f * Time.fixedDeltaTime;
            Renderer.material.color = Color;
            yield return null;
        }
        while(Color.a <= 1f);
    }

    private void GetRandomAnimation()
    {
        int a = Random.Range(0,3);
        if(a == 0)
        {
        anim.SetInteger("isInt", 0);
        }
        else if(a == 1)
        {
        anim.SetInteger("isInt", 1);   
        }
        else
        {
            anim.SetInteger("isInt", 2);
        }
        
    }
}
