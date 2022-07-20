using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthSliderEffect : MonoBehaviour
{
    private GameObject BossUISymbol;
    private bool lifeLoaded, triggerEnrage,BossDefeated;
    private void Awake() 
    {
        BossDefeated = false;
        triggerEnrage = false;
        lifeLoaded = false;
    }
    private void FixedUpdate() 
    {
        if(lifeLoaded == false)
        {
            LoadHealthBar();
        }
        //Boss Enrage:
        if(triggerEnrage == false 
            && lifeLoaded == true    
            && transform.localScale.x < 0.8652256f)
        {
           // Debug.Log("enrage time");
            triggerEnrage = true;
            GameObject.FindObjectOfType<CountDownTimer>().TickFaster = 0.8f;
            GameObject.FindObjectOfType<BossAlienScript>().EnrageTime();
        }
        //Debug.Log(transform.position.x);
        //Boss Death:
        if(transform.localScale.x < 0.0198f 
            && lifeLoaded == true
            && BossDefeated == false) 
        {
            BossDefeated = true;
            BossUISymbol = GameObject.Find("BossUISymbol(Clone)");
            GameObject.FindObjectOfType<ReloadEffects>().Flashbang();
            GameObject.FindObjectOfType<BossAlienScript>().BossDefeat();
            GameObject.FindObjectOfType<CountDownTimer>().BossWon = true;
            Destroy(BossUISymbol);
            Destroy(gameObject);
           // Debug.Log("boss defeated");
        }
    }
    private IEnumerator BossHealthBar()
    {
        
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(209, 203, 149, 255);
        transform.position = new Vector3(transform.position.x-0.0064f,transform.position.y,transform.position.z);               //0.0064
        transform.localScale = new Vector3(transform.localScale.x-0.01276f,transform.localScale.y,transform.localScale.z);      //0.01276
        yield return new WaitForSeconds(0.1f);
            if(transform.position.x > -0.6674f
            &&transform.localScale.x > 0.8652256f)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(64, 152, 94, 255);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color32(26, 100, 78, 255);
            }
    }

        private void LoadHealthBar()
    {
        transform.position = new Vector3(transform.position.x+0.0032f,transform.position.y,transform.position.z);               
        transform.localScale = new Vector3(transform.localScale.x+0.00638f,transform.localScale.y,transform.localScale.z);            
        if(transform.position.x >= 0.0f
            && transform.localScale.x >= 2.2f)
        {
            lifeLoaded = true;
        }
        
    }
        public void CallBossHealthBar()
    {
        StartCoroutine(BossHealthBar());
    }
}
