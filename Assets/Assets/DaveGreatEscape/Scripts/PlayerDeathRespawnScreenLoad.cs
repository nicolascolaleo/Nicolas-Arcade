using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathRespawnScreenLoad : MonoBehaviour
{
    private int randomTransition;
    private float randomRotation, transitionTime;
    public GameObject ClockEffect, CircleEffect, SnakeEffect, StripesEffect, ArcadeMachine, RespawnPos;
    Vector3 arcade;
    public void LoadRespawnPoint()
    {
        StartCoroutine(LoadLevel());
    }
    
    IEnumerator LoadLevel()
    {
        randomTransition = Random.Range(1,5);
        if(randomTransition == 1)
        {
            transitionTime = 1.8f;
            Instantiate(ClockEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(transitionTime);
        }
        else if(randomTransition == 2)
        {
            transitionTime = 1.8f;
            Instantiate(CircleEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(transitionTime);
        }
        else if(randomTransition == 3)
        {
            transitionTime = 1.8f;
            Instantiate(SnakeEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(transitionTime);
        }
        else if(randomTransition == 4)
        {
            transitionTime = 1.8f;
            Instantiate(StripesEffect, transform.position, transform.rotation);
            yield return new WaitForSeconds(transitionTime);
        }

        if(RespawnPos.transform.position.x == -3.38f)
        {
            ArcadeMachine.transform.position = new Vector3(0,0,-1);
            GameObject.FindObjectOfType<ReloadEffects>().SimpleScreenTransition();
            yield return new WaitForSeconds(0.01f);
            GameObject.FindObjectOfType<DestroyOnCall>().DestroyObject();
        }
        else if(RespawnPos.transform.position.x == 36.87f)
        {
            ArcadeMachine.transform.position = new Vector3(40.96f,0,-1);
            GameObject.FindObjectOfType<ReloadEffects>().SimpleScreenTransition();
            yield return new WaitForSeconds(0.01f);
            GameObject.FindObjectOfType<DestroyOnCall>().DestroyObject();
        }
        yield return null;
    }
}
