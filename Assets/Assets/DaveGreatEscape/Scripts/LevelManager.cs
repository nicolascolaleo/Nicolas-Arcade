using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform RespawnPos;
    public GameObject PlayerPrefab, RespawnPlayer;
    private GameObject respawn;

    public bool IsKeyEarned;

    private void Awake() 
    {
        IsKeyEarned = false;
        instance = this;    
    }
    public void Respawn()
    {
        StartCoroutine(PlayerRespawn());
    }
        IEnumerator PlayerRespawn()
    {
        GameObject.FindObjectOfType<PlayerDeathRespawnScreenLoad>().LoadRespawnPoint();
        yield return new WaitForSeconds(2.8f);
        respawn = Instantiate(RespawnPlayer, RespawnPos.position, Quaternion.identity);
        yield return new WaitForSeconds(0.2f);
        Instantiate(PlayerPrefab, RespawnPos.position, Quaternion.identity);;
        Destroy(respawn, 0.63f);
        PlayerPrefab.GetComponent<PlayerController>().PlayerControl = true;
    }
}
