using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBoxScript : MonoBehaviour
{
    private Animator anim;
    AnimatorClipInfo[] animatorinfo;
    private string current_animation;
    private bool isBoxFull, isBoxClosing, isFinishedText;
    public GameObject AlienPortrait;
    void Start()
    {
        isFinishedText = false;
        isBoxClosing = false;
        isBoxFull = false;
        anim = GetComponent<Animator>();    
        anim.enabled = false;
    }

    void Update()
    {
        animatorinfo = this.anim.GetCurrentAnimatorClipInfo(0);
        current_animation = animatorinfo[0].clip.name;
       
        if(isBoxFull == false)
        {
            TextBoxEffect();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) 
            && current_animation != "ForthBoxLoop"
            && isFinishedText == true)
        {
            anim.SetTrigger("NextText");
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)
                && isFinishedText == true)
        {
            anim.SetBool("isBoxClosing", true);
            Destroy(gameObject.transform.GetChild(0).gameObject);
            isBoxClosing = true;
        }

        if(isBoxClosing == true)
        {
            CloseTextBoxEffect();
        }
    }
    private void TextBoxEffect()
    {
        transform.localScale = new Vector2(transform.localScale.x + 0.15f * Time.fixedDeltaTime,
        transform.localScale.y + 0.15f * Time.fixedDeltaTime);            
        if(transform.localScale.x >= 1f)
        {
            transform.localScale = new Vector2(1,1);
            isBoxFull = true;
            anim.enabled = true;
            Instantiate(AlienPortrait, new Vector2(transform.position.x -2.35f, transform.position.y), transform.rotation, gameObject.transform);
        }
    }
        private void CloseTextBoxEffect()
    {
        transform.localScale = new Vector2(transform.localScale.x - 0.3f * Time.fixedDeltaTime,
        transform.localScale.y - 0.3f * Time.fixedDeltaTime);
        if(transform.localScale.x <= 0f)
        {
            transform.localScale = new Vector2(0,0);
            isBoxClosing = false;
            GameObject.FindObjectOfType<CallTextBoxOnDelay>().isFirstSceneOver = true;
            Destroy(gameObject);
        }
    }

    private void isFinishedTextTrue()
    {
        isFinishedText = true;
    }
    private void isFinishedTextFalse()
    {
        isFinishedText = false;
    }
}
