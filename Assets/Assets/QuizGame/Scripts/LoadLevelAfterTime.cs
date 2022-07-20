using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour
{
    private float delayBeforeLoading = 3f;
    private float timesUp;
    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Correct") != null)
        {timesUp += Time.deltaTime;

            if(timesUp > delayBeforeLoading)
            {
                if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("QuizGameQuestionOne"))
                {
                    SceneManager.LoadScene("QuizGameQuestionTwo");
                }
                else if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("QuizGameQuestionTwo"))
                {
                    SceneManager.LoadScene("QuizGameQuestionThree");
                }
                else if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("QuizGameQuestionThree"))
                {
                    SceneManager.LoadScene("QuizGameQuestionFour");
                }
                else if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("QuizGameQuestionFour"))
                {
                    SceneManager.LoadScene("QuizGameQuestionFive");
                }
            }
        }

    }
}


