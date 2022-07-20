using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverQuizGame : MonoBehaviour
{
    public GameObject GameOverPrefab, ResetOrQuitAnim, FinalWinSprite;
    private float timer = 1.5f;
    private bool playOnce;
    private void Awake() 
    {
        playOnce = true;
    }
    public void Update()
    {
        if(GameObject.FindGameObjectWithTag("Wrong") != null || GameObject.FindGameObjectWithTag("Finish") != null)
        {
            timer -= Time.deltaTime;
            if(timer <=0 && playOnce == true)
            {
                if(GameObject.FindGameObjectWithTag("Finish") == null)
                {
                    Instantiate(GameOverPrefab, new Vector2(0,3), transform.rotation);
                }
                Instantiate(ResetOrQuitAnim, new Vector2(0,-3), transform.rotation);
                playOnce = false;
            }
            if(playOnce == false 
                && Input.GetKeyDown(KeyCode.Return) || GameObject.FindGameObjectWithTag("Finish") != null
                && Input.GetKeyDown(KeyCode.Return))
            {
                gameObject.GetComponent<ReloadEffects>().SceneNumber = 5;
                gameObject.GetComponent<ReloadEffects>().CallLoadEffect();
            }
        }
    }
}
