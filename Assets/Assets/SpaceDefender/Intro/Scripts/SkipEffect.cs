using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipEffect : MonoBehaviour
{
   private Animator anim;
   private bool isStartedSkipLoad;

   private void Awake() 
   {
    isStartedSkipLoad = false;
    anim = GetComponent<Animator>();
   }

   private void Update() 
   {
    if(Input.GetKey(KeyCode.Space))
    {
        anim.SetBool("isHoldingSpacebar", true);
        anim.SetFloat("Speed",1.0f);
        StartCoroutine(waitForSeconds());
        isStartedSkipLoad = true;
    }
    else if(isStartedSkipLoad == true
            && !Input.GetKey(KeyCode.Space))
    {
        anim.SetBool("isHoldingSpacebar", true);
        anim.SetFloat("Speed", -1.0f);
    }

   }
   private IEnumerator waitForSeconds()
   {
    yield return new WaitForSeconds(0.1f);
   }

   private void SetBoolFalse()
   {
    if(isStartedSkipLoad == true)
    {
        anim.SetBool("isHoldingSpacebar", false);
        isStartedSkipLoad = false;
    }
   }
   private void SkipIntro()
   {
    FindObjectOfType<MainMenuEsc>().LoadGameAfterSkip();
    Destroy(gameObject);
   }
}
