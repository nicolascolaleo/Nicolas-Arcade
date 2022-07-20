using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePointScript : MonoBehaviour
{
    public GameObject NewPlayer, BossUISymbol, BossLifeBar;
    public Transform RespawnPos;
    private GameObject Player;
    private int MaxHearts;
    public int TotalLife;

    private void Awake() 
    {
        MaxHearts = 2;
        TotalLife = 3;
    }
    private void RemoveLife()
    {
        Destroy(this.transform.GetChild(MaxHearts).gameObject);
        MaxHearts--;
        TotalLife--;
       // Debug.Log("total life = " + TotalLife + " , max hearts = " + MaxHearts);
    }
    IEnumerator PlayerRespawn()
    {
        float invulnerability = 4f;
        float backToVulnerable = Time.time + invulnerability;
        yield return new WaitForSeconds(2f);
        Player = Instantiate(NewPlayer, RespawnPos.position, transform.rotation);
        Player.GetComponent<PolygonCollider2D>().enabled = false;

        while(Time.time < backToVulnerable)
        {   
             Player.GetComponent<Renderer>().enabled = false;
             yield return new WaitForSeconds(0.05f);
             Player.GetComponent<Renderer>().enabled = true;
             yield return new WaitForSeconds(0.05f);
        }
        Player.GetComponent<PolygonCollider2D>().enabled = true;
    }

    public void CallPlayerRespawn()
    {
        RemoveLife();
        if(TotalLife > 0)
        {
            StartCoroutine(PlayerRespawn());  
        }
    }

    public void BossUI()
    {
        Instantiate(BossUISymbol, new Vector2(gameObject.transform.position.x + 2.2f, gameObject.transform.position.y), Quaternion.identity, gameObject.transform);
        Instantiate(BossLifeBar, new Vector2(gameObject.transform.position.x + 3.6f, gameObject.transform.position.y), Quaternion.identity, gameObject.transform);
    }
}
