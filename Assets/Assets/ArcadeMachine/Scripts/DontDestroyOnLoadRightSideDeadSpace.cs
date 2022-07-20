using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadRightSideDeadSpace : MonoBehaviour
{
    public static DontDestroyOnLoadRightSideDeadSpace RightSide;
    private GameObject NewParent;
    private void Awake() 
    {
        if (RightSide == null)
        {
            RightSide = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update() 
    {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByBuildIndex(1))
        {
            Destroy(gameObject);
        }
    }
    public void ChangeToDaveAnimRightSide()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<SideAnimationsScript>().ChangeToDaveSideAnim();
        }
       // gameObject.transform.GetChild(0).localPosition = new Vector2(0, 0);
       // gameObject.transform.GetChild(1).localPosition = new Vector2(-3f, 5.55f);
       // Debug.Log(gameObject.transform.GetChild(0).position);
       // Debug.Log(gameObject.transform.GetChild(1).position);
    }
    public void ChangeToSpaceDefenderAnimRightSide()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<SideAnimationsScript>().ChangeToSpaceDefenderSideAnim();
        }
     //  gameObject.transform.GetChild(0).localPosition = new Vector2(0, 3.05f);
      //  gameObject.transform.GetChild(1).localPosition = new Vector2(-3f, 3.05f);
       // Debug.Log(gameObject.transform.GetChild(0).position);
       // Debug.Log(gameObject.transform.GetChild(1).position);
    }
    public void ChangeToQuizGameAnimRightSide()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<SideAnimationsScript>().ChangeToQuizGameSideAnim();
        }
      //  gameObject.transform.GetChild(0).localPosition = new Vector2(0, 0);
      //  gameObject.transform.GetChild(1).localPosition = new Vector2(-3f, 6.73f);
       // Debug.Log(gameObject.transform.GetChild(0).position);
       // Debug.Log(gameObject.transform.GetChild(1).position);
    }
    public void ChangeToBrickBreakerAnimRightSide()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<SideAnimationsScript>().ChangeToBrickBreakerSideAnim();
        }
       // gameObject.transform.GetChild(0).localPosition = new Vector2(0, 0);
      //  gameObject.transform.GetChild(1).localPosition = new Vector2(-3f, 5.75f);
      //  Debug.Log(gameObject.transform.GetChild(0).position);
      //  Debug.Log(gameObject.transform.GetChild(1).position); 
    }

    public void DaveGameParentControllerRightSide()
    {
        Debug.Log("start");
        if(SceneManager.GetActiveScene () == SceneManager.GetSceneByBuildIndex (12))
        {
            
            NewParent = GameObject.Find("Arcade UI Canvas");//make child of Arcade UI Canvas
            transform.parent = NewParent.transform;
        }
        else if(SceneManager.GetActiveScene () == SceneManager.GetSceneByBuildIndex (13))
        { 
            do
            {
                gameObject.transform.position = new Vector3(9.6f,0,0);
            }
            while(gameObject.transform.position != new Vector3(9.6f,0,0));
            NewParent = GameObject.Find("CM vcam1");
            transform.parent = NewParent.transform;
            //CM vcam1
        }
    }
    public void CallToNotDestroyRightSide()
    {
        RightSide = this;
        DontDestroyOnLoad(gameObject);
    }
    public void DetachRightSide()
    {
        transform.parent = null;
        CallToNotDestroyRightSide();
    }
    public void ResetPosRightSide()
    {
        do
        {
            gameObject.transform.position = new Vector3(9.6f,0,0);
        }
        while(gameObject.transform.position != new Vector3(9.6f,0,0));
    }
}
