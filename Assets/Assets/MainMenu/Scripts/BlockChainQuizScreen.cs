using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockChainQuizScreen : MonoBehaviour
{
    public GameObject spaceDefenders;
    public GameObject blockChainQuiz;
    public GameObject bricksBreaker;
    
    private void Awake() 
    {
        DontDestroyOnLoadLeftSideDeadSpace.LeftSide.ChangeToQuizGameAnimLeftSide();
        DontDestroyOnLoadRightSideDeadSpace.RightSide.ChangeToQuizGameAnimRightSide();    
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
            SceneManager.LoadScene("QuizGameQuestionOne");
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LoadingScene");
        }
        
    }

    public void PickAnotherGame()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Destroy(gameObject);
            Instantiate(spaceDefenders, Vector2.zero, Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(gameObject);
            Instantiate(bricksBreaker, Vector2.zero, Quaternion.identity);
        }
    }
}
