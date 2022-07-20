using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroyOnLoadLeftSideDeadSpace : MonoBehaviour
{
    public static DontDestroyOnLoadLeftSideDeadSpace LeftSide;
    private GameObject NewParent;
    private void Awake() 
    {
        if (LeftSide == null)
        {
            LeftSide = this;
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

    public void ChangeToDaveAnimLeftSide()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<SideAnimationsScript>().ChangeToDaveSideAnim();
        }
       // gameObject.transform.GetChild(0).localPosition = new Vector2(0, 0);
       // gameObject.transform.GetChild(1).localPosition = new Vector2(-3f, 5.55f);
      //  Debug.Log(gameObject.transform.GetChild(0).position);
      //  Debug.Log(gameObject.transform.GetChild(1).position); 
    }
    public void ChangeToSpaceDefenderAnimLeftSide()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<SideAnimationsScript>().ChangeToSpaceDefenderSideAnim();
        }
       // gameObject.transform.GetChild(0).localPosition = new Vector2(0, 3.05f);
       // gameObject.transform.GetChild(1).localPosition = new Vector2(-3f, 3.05f);
      //  Debug.Log(gameObject.transform.GetChild(0).position);
      //  Debug.Log(gameObject.transform.GetChild(1).position);
    }
    public void ChangeToQuizGameAnimLeftSide()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<SideAnimationsScript>().ChangeToQuizGameSideAnim();
        }
      //  gameObject.transform.GetChild(0).localPosition = new Vector2(0, 0);
       // gameObject.transform.GetChild(1).localPosition = new Vector2(-3f, 6.73f);
       // Debug.Log(gameObject.transform.GetChild(0).position);
       // Debug.Log(gameObject.transform.GetChild(1).position);
    }
    public void ChangeToBrickBreakerAnimLeftSide()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<SideAnimationsScript>().ChangeToBrickBreakerSideAnim();
        }
       // gameObject.transform.GetChild(0).localPosition = new Vector2(0, 0);
       // gameObject.transform.GetChild(1).localPosition = new Vector2(-3f, 5.75f);
      //  Debug.Log(gameObject.transform.GetChild(0).position);
      //  Debug.Log(gameObject.transform.GetChild(1).position); 
    }
    

    public void DaveGameParentControllerLeftSide()
    {
        if(SceneManager.GetActiveScene () == SceneManager.GetSceneByBuildIndex (12))
        {
            NewParent = GameObject.Find("Arcade UI Canvas");//make child of Arcade UI Canvas
            transform.parent = NewParent.transform;
        }
        else if(SceneManager.GetActiveScene () == SceneManager.GetSceneByBuildIndex (13))
        {
            do
            {
                gameObject.transform.position = new Vector3(-9.6f,0,0);
            }
            while(gameObject.transform.position != new Vector3(-9.6f,0,0));
            NewParent = GameObject.Find("CM vcam1");
            transform.parent = NewParent.transform;
            //CM vcam1
        }
    }
    public void CallToNotDestroyLeftSide()
    {
        LeftSide = this;
        DontDestroyOnLoad(gameObject);
    }
    public void DetachLeftSide()
    {
        transform.parent = null;
        CallToNotDestroyLeftSide();
    }
    public void ResetPosLeftSide()
    {
        do
        {
            gameObject.transform.position = new Vector3(-9.6f,0,0);
        }
        while(gameObject.transform.position != new Vector3(-9.6f,0,0));
    }
}
