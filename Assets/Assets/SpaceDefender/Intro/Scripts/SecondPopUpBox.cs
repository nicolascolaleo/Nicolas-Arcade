using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPopUpBox : MonoBehaviour
{
    private Animator anim;
    AnimatorClipInfo[] animatorinfo;
    private string current_animation;
    private bool isBoxFull, isBoxClosing, isFinishedText;
    public GameObject AlienHiddenPortrait, PlayerPortrait;
    private GameObject SkipButton;
    void Start()
    {
        SkipButton = GameObject.Find("SkipButton");
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
            && current_animation != "SecondSceneBoxSixthTextAnimLoop" 
            && current_animation != "SecondSceneBoxSecondTextLoopAnim"
            && current_animation != "SecondSceneBoxForthTextLoopAnim"
            && isFinishedText == true)
        {
            //Debug.Log(current_animation);
            anim.SetTrigger("NextText");
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)
            && current_animation == "SecondSceneBoxSecondTextLoopAnim"
            && isFinishedText == true)
        {
           // Debug.Log(current_animation);
            anim.SetTrigger("NextText");
            anim.SetBool("isPlayerPortrait" , true);
            Destroy(gameObject.transform.GetChild(0).gameObject);
            Instantiate(PlayerPortrait, new Vector2(transform.position.x -2.35f, transform.position.y), transform.rotation, gameObject.transform);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)
            && current_animation == "SecondSceneBoxForthTextLoopAnim"
            && isFinishedText == true)
            {
            //Debug.Log(current_animation);
            anim.SetTrigger("NextText");
            anim.SetBool("isPlayerPortrait" , false);
            Destroy(gameObject.transform.GetChild(0).gameObject);
            Instantiate(AlienHiddenPortrait, new Vector2(transform.position.x -2.35f, transform.position.y), transform.rotation, gameObject.transform); 
            }
        else if(Input.GetKeyDown(KeyCode.DownArrow)
            && current_animation == "SecondSceneBoxSixthTextAnimLoop"
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
            Instantiate(AlienHiddenPortrait, new Vector2(transform.position.x -2.35f, transform.position.y), transform.rotation, gameObject.transform);
        }
    }
        private void CloseTextBoxEffect()
    {
        transform.localScale = new Vector2(transform.localScale.x - 0.3f * Time.fixedDeltaTime,
        transform.localScale.y - 0.3f * Time.fixedDeltaTime);
        if(transform.localScale.x <= 0f)
        {
            Destroy(SkipButton);
            transform.localScale = new Vector2(0,0);
            isBoxClosing = false;
            GameObject.FindObjectOfType<CallTextBoxOnDelay>().isSecondSceneOver = true;
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
