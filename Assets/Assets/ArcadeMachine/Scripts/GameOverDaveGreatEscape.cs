using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDaveGreatEscape : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameOverPrefab, ResetOrQuitAnim, AreaName, EndLevelBlacout;
    private float timer = 1.5f;
    private bool playOnce, clickOnce;
    public bool isLevelWon;
    private void Awake() 
    {
        Instantiate(AreaName, new Vector2(0,2), transform.rotation, gameObject.transform);
        clickOnce = true;   
        playOnce = true; 
    }
    private void Start() 
    {
        StartCoroutine(UpdateSideAnims());
    }
    private void Update() 
    {
            if(GameObject.Find("LifePointsHealthPoints").GetComponent<DaveHealthPoints>().HealthPoints <= 0)
            {
                GameOverDaveGame();
            }    
    }
    public void GameOverDaveGame()
    {
        timer -= Time.deltaTime;
        if(timer <=0 && playOnce == true)
        {
            Instantiate(GameOverPrefab, new Vector2(transform.position.x,3), transform.rotation);
            Instantiate(ResetOrQuitAnim, new Vector2(transform.position.x,-3), transform.rotation);
            playOnce = false;
        }
        if(playOnce == false && Input.GetKeyDown(KeyCode.Return)
            && clickOnce == true)
        {
            clickOnce = false;
            gameObject.GetComponent<ReloadEffects>().SceneNumber = 12;
            DetachSideScreenEffects();
            gameObject.GetComponent<ReloadEffects>().CallLoadEffect();
        }
    }

    public void LevelCompletedEffect()
    {
        Instantiate(EndLevelBlacout, gameObject.transform);
    }
    public void NextLevel()
    {
            gameObject.GetComponent<ReloadEffects>().SceneNumber = 13;
            gameObject.GetComponent<ReloadEffects>().CallLoadEffect();
    }
    public void DetachSideScreenEffects()
    {
        while (gameObject.transform.childCount > 0)
        {
            foreach (Transform child in gameObject.transform)
            {
               // Debug.Log(gameObject.transform.childCount);
                gameObject.transform.DetachChildren();
            }
        }
        GameObject.FindObjectOfType<DontDestroyOnLoadLeftSideDeadSpace>().CallToNotDestroyLeftSide();
        GameObject.FindObjectOfType<DontDestroyOnLoadRightSideDeadSpace>().CallToNotDestroyRightSide();
    }
    private IEnumerator UpdateSideAnims()
    {
        yield return new WaitForSeconds(0.00001f);
        GameObject.FindObjectOfType<DontDestroyOnLoadLeftSideDeadSpace>().ResetPosLeftSide();
        GameObject.FindObjectOfType<DontDestroyOnLoadRightSideDeadSpace>().ResetPosRightSide();
        GameObject.FindObjectOfType<DontDestroyOnLoadLeftSideDeadSpace>().ChangeToDaveAnimLeftSide();
        GameObject.FindObjectOfType<DontDestroyOnLoadRightSideDeadSpace>().ChangeToDaveAnimRightSide();
    }
}
