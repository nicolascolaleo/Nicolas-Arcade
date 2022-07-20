using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public GameObject ArrowUpKey;
    private GameObject ScreenSideEffectLeft, ScreenSideEffectRight;
    private Vector2 arrowPos;
    private Animator anim;
    private bool isDoorOpen;
    void Awake() 
    {   
        ScreenSideEffectLeft = GameObject.Find("LeftSideDeadSpace");
        ScreenSideEffectRight = GameObject.Find("RightSideDeadSpace");
        arrowPos = new Vector2(transform.position.x, transform.position.y + 1.2f);
        anim = GetComponent<Animator>();    
        anim.enabled = false;
        isDoorOpen = false;
    }

    private void Update() 
    {
            if(transform.childCount > 0 
            && Input.GetKeyDown(KeyCode.UpArrow)
            && isDoorOpen == true)
            {
                GameObject.FindGameObjectWithTag("Player").SetActive (false);
                Destroy(gameObject.transform.GetChild(0).gameObject);
                anim.SetBool("isDaveGoingUp", true);
                StartCoroutine(LoadNextScene());
            }    
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player") 
            && GameObject.FindObjectOfType<LevelManager>().IsKeyEarned == true
            && isDoorOpen == false)
        {
            StartCoroutine(WaitForGateToOpen());
            anim.enabled = true;
        }

    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player") 
            && isDoorOpen == true
            && transform.childCount <= 0)
        {
            Instantiate(ArrowUpKey, arrowPos, transform.rotation, gameObject.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(transform.childCount > 0)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
    }

    private IEnumerator WaitForGateToOpen()
    {
        yield return new WaitForSeconds(0.6f);
        GameObject.FindObjectOfType<KeyIcon>().IsKeyUsed();
        isDoorOpen = true;
    }
    private IEnumerator LoadNextScene()
    {
        GameObject.FindObjectOfType<GameOverDaveGreatEscape>().DetachSideScreenEffects();
        GameObject.FindObjectOfType<GameOverDaveGreatEscape>().LevelCompletedEffect();
        yield return new WaitForSeconds(2.9f);
        GameObject.FindObjectOfType<ReloadEffects>().SceneNumber = 13;
        GameObject.FindObjectOfType<ReloadEffects>().JustLoadScene();
    }

}
