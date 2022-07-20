using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BricksBreaker : MonoBehaviour
{
    public GameObject daveGreatEscape;
    public GameObject bricksBreaker;
    public GameObject blockChainQuiz;

    private void Awake() 
    {
        DontDestroyOnLoadLeftSideDeadSpace.LeftSide.ChangeToBrickBreakerAnimLeftSide();
        DontDestroyOnLoadRightSideDeadSpace.RightSide.ChangeToBrickBreakerAnimRightSide();
    }
    void Update()
    {
        LoadNextScene();
        PickAnotherGame();
    }

    public void LoadNextScene()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("BricksBreakerLevelOne");
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LoadingScene");
        }
        
    }

    private void BricksBreakerScreen()
    {
        Instantiate(bricksBreaker, Vector2.zero, Quaternion.identity);
        Destroy(gameObject);
    }

    public void PickAnotherGame()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Destroy(gameObject);
            Instantiate(blockChainQuiz, Vector2.zero, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(gameObject);
            Instantiate(daveGreatEscape, Vector2.zero, Quaternion.identity);
        }
    }
}
