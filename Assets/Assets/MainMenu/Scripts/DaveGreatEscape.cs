using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaveGreatEscape : MonoBehaviour
{
    public GameObject spaceDefenders;
    public GameObject daveGreatEscape;
    public GameObject bricksBreaker;

    private void Awake() 
    {
        DontDestroyOnLoadLeftSideDeadSpace.LeftSide.ChangeToDaveAnimLeftSide();
        DontDestroyOnLoadRightSideDeadSpace.RightSide.ChangeToDaveAnimRightSide();
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
            SceneManager.LoadScene("DaveGreatEscapeLevelOne");
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
            Instantiate(bricksBreaker, Vector2.zero, Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(gameObject);
            Instantiate(spaceDefenders, Vector2.zero, Quaternion.identity);
        }
    }
}

