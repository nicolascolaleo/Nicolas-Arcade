using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerEndingScene : MonoBehaviour
{
    public Transform playerInCastleTrigger;
    public GameObject TheEndPrefab;
    private GameObject BeforeCharCastlePart, Player, isCinemachineMoving, ArcadeMachine;
    Vector2 cinemachineStartPos;
    Vector2 cinemachineEndPos;
    public AudioClip SoundTrack;

    private void Awake() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        BeforeCharCastlePart = GameObject.Find("BeforeChar");
        isCinemachineMoving = GameObject.Find("isCinemachineMoving");
        ArcadeMachine = GameObject.Find("Arcade UI Canvas");
        cinemachineStartPos = isCinemachineMoving.transform.position;
    }
    private void Start() 
    {
        SoundManager.instance.PlayMusic(SoundTrack);
        StartCoroutine(WaitForSec());
    }
    void Update()
    {
        isPlayerInsideCastle();
        CinemachineFollowsEffect();
    }
    private void isPlayerInsideCastle()
    {
        if (Player.transform.position.x >= playerInCastleTrigger.transform.position.x)
        {
            BeforeCharCastlePart.SetActive(false);
        }
        else
        {
            BeforeCharCastlePart.SetActive(true);
        }
    }
    private void CinemachineFollowsEffect()
    {
        if (Player.transform.position.x > cinemachineStartPos.x
            && ArcadeMachine.transform.position.x <=9.55f)
        {
            isCinemachineMoving.transform.position = new Vector2(Player.transform.position.x, isCinemachineMoving.transform.position.y);
            cinemachineEndPos.x = ArcadeMachine.transform.position.x;
        }

        if(Player.transform.position.x < cinemachineEndPos.x
            && Player.transform.position.x > cinemachineStartPos.x)
        {
            isCinemachineMoving.transform.position = new Vector2(Player.transform.position.x, isCinemachineMoving.transform.position.y);
        }
    }
    private IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(0.00001f);
        GameObject.FindObjectOfType<DontDestroyOnLoadLeftSideDeadSpace>().DaveGameParentControllerLeftSide();
        GameObject.FindObjectOfType<DontDestroyOnLoadRightSideDeadSpace>().DaveGameParentControllerRightSide();
    }

    public void TheEnd()
    {
        Instantiate(TheEndPrefab, new Vector2(8.0f, 1.0f), transform.rotation);
    }
}
