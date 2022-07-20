using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeCallToEnd : MonoBehaviour
{
    public void EndGame()
    {
        // ADD AGAIN THE SEQUANCE TO TRANSFORM.PARENT = NULL ON RIGHT AND LEFT SIDE ANIMATIONS,
        // THEN CALL DONT DESTROY, AND ON AWAKE OF GAMEOVERDAVEGREATESCAPE RESET THE TRANSFORM POSITION
        GameObject.FindObjectOfType<DontDestroyOnLoadLeftSideDeadSpace>().DetachLeftSide();
        GameObject.FindObjectOfType<DontDestroyOnLoadRightSideDeadSpace>().DetachRightSide();
        gameObject.GetComponent<ReloadEffects>().SceneNumber = 12;
        gameObject.GetComponent<ReloadEffects>().CallLoadEffect();
    }
}
