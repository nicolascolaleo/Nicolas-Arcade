using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverSpaceDefenders : MonoBehaviour
{
    public GameObject Timer, Player, GameOverPrefab, ResetOrQuitAnim;
    private float timer;
    private bool playOnce, clickOnce;
    private void Awake() 
    {
        timer = 1.5f;
        playOnce = true;
        clickOnce = true;
    }
    public void Update()
    {
        if(GameObject.FindObjectOfType<LifePointScript>().TotalLife <=0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <=0f && playOnce == true)
        {
            Timer.GetComponent<CountDownTimer>().StopTimer = true;
            Instantiate(GameOverPrefab, new Vector2(0,2.8f), transform.rotation);
            Instantiate(ResetOrQuitAnim, new Vector2(0,-3), transform.rotation);
            playOnce = false;
        }
        if(playOnce == false && Input.GetKeyDown(KeyCode.Return)
            && clickOnce == true)
        {
            clickOnce = false;
            gameObject.GetComponent<ReloadEffects>().SceneNumber = 4;
            gameObject.GetComponent<ReloadEffects>().CallLoadEffect();
        }
    }
    public void OnlyIfWin()
    {
        Instantiate(ResetOrQuitAnim, new Vector2(0,-3), transform.rotation);
        playOnce = false;
        if(playOnce == false && Input.GetKeyDown(KeyCode.Return)
            && clickOnce == true)
        {
            clickOnce = false;
            gameObject.GetComponent<ReloadEffects>().SceneNumber = 4;
            gameObject.GetComponent<ReloadEffects>().JustLoadScene();
        }
    }
}


