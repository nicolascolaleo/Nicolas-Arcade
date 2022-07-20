using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBricksBreaker : MonoBehaviour
{
    public GameObject Ball, GameOverPrefab, ResetOrQuitAnim, ReadySetGoAnim, LevelCompletedAnim;
    private float timer = 1.5f;
    private bool isLevelCompleted, playOnce, clickOnce;

    private void Awake() 
    {
        FindObjectOfType<Ball>().onlyOnStartGame = true;
        isLevelCompleted = false;
        clickOnce = true;
        playOnce = true;
        Invoke(nameof(ReadySetGo), 0.5f);
    }

    public void Update()
    {
        GameOver();
        LevelCompleted();
    }

    private void GameOver()
    {
        if(GameObject.FindGameObjectsWithTag ("Ball").Length == 0 && isLevelCompleted == false)
        {
            FindObjectOfType<Player>().playerMove = false;
            timer -= Time.deltaTime;
            if(timer <=0 && playOnce == true)
            {
                Instantiate(GameOverPrefab, new Vector2(0,3), transform.rotation);
                Instantiate(ResetOrQuitAnim, new Vector2(0,-3), transform.rotation);
                playOnce = false;
            }
            if(playOnce == false 
                && Input.GetKeyDown(KeyCode.Return)
                && clickOnce == true)
            {
                clickOnce = false;
                gameObject.GetComponent<ReloadEffects>().SceneNumber = 10;
                gameObject.GetComponent<ReloadEffects>().CallLoadEffect();
            }
        }    
    }

    private void LevelCompleted()
    {
        if(GameObject.FindGameObjectsWithTag ("Bricks").Length == 0)
        {
            if(playOnce == true)
            {
                Instantiate(LevelCompletedAnim, new Vector2(0,2.5f), transform.rotation);
                playOnce = false;
                timer = 8f;
            }
            isLevelCompleted = true;
            timer -= Time.deltaTime;
            if (timer <=0 && SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("BricksBreakerLevelOne") )
            {
                SceneManager.LoadScene("BricksBreakerLevelTwo"); 
            }
            else if (timer <=0 && SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("BricksBreakerLevelTwo"))
            {
            Instantiate(ResetOrQuitAnim, new Vector2(0,-3), transform.rotation);
            if(Input.GetKeyDown(KeyCode.Return) 
                && clickOnce == true)
            {
                clickOnce = false;
                gameObject.GetComponent<ReloadEffects>().SceneNumber = 10;
                gameObject.GetComponent<ReloadEffects>().CallLoadEffect();
            }
            }
        }
    }

    private void ReadySetGo()
    {
        Instantiate(ReadySetGoAnim, new Vector2(0,2.5f), transform.rotation);
    }
}
