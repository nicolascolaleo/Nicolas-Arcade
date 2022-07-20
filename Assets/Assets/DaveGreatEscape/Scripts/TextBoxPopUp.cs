using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxPopUp : MonoBehaviour
{
    private Animator anim;
    private bool isBoxFull;
    public bool isBoxReversed;
    void Awake()
    {
        isBoxReversed = false;
        isBoxFull = false;
        anim = GetComponent<Animator>();    
        anim.enabled = false;
    }

    void Update()
    {
        if(isBoxFull == false)
        {
            TextBoxEffect();
        }
        if(isBoxReversed == true)
        {
            TextBoxEffectReverse();
        }
    }
    private void TextBoxEffect()
    {
        transform.localScale = new Vector2(transform.localScale.x + 0.85f * Time.fixedDeltaTime,
        transform.localScale.y + 0.85f * Time.fixedDeltaTime);            
        if(transform.localScale.x >= 1f)
        {
            transform.localScale = new Vector2(1,1);
            isBoxFull = true;
            anim.enabled = true;
        }
    }

    private void TextBoxEffectReverse()
    {
         transform.localScale = new Vector2(transform.localScale.x - 0.0078f,transform.localScale.y - 0.0078f);
        if(transform.localScale.x <= 0f)
        {
            transform.localScale = new Vector2(0,0);
            isBoxReversed = false;
            Destroy(gameObject);
        }
    }
}
