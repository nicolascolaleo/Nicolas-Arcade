using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceDefenders : MonoBehaviour
{

    public GameObject spaceDefenders;
    public GameObject blockChainQuiz;
    public GameObject daveGreatEscape;

    public AudioSource SpaceDefendersThemeMusic;

    private void Awake() 
    {
        DontDestroyOnLoadLeftSideDeadSpace.LeftSide.ChangeToSpaceDefenderAnimLeftSide();
        DontDestroyOnLoadRightSideDeadSpace.RightSide.ChangeToSpaceDefenderAnimRightSide();
        SpaceDefendersThemeMusic.Play();
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
            SceneManager.LoadScene("Intro");
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LoadingScene");
        }
        
    }

    private void SpaceDefendersScreen()
    {
        Instantiate(spaceDefenders, Vector2.zero, Quaternion.identity);
        Destroy(gameObject);
    }

    public void PickAnotherGame()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(gameObject);
            Instantiate(blockChainQuiz, Vector2.zero, Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Destroy(gameObject);
            Instantiate(daveGreatEscape, Vector2.zero, Quaternion.identity);
        }
    }
}
