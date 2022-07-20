using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public GameObject ArrowUpKey;
    private bool isPlayerIn;
    void Awake()
    {
        isPlayerIn = false;
    }


    void Update()
    {
        if( isPlayerIn == true
        && Input.GetKeyDown(KeyCode.UpArrow)
        && GameObject.FindObjectOfType<PlayerController>().groundTouch == true)
        {
            isPlayerIn = false;
            Destroy(gameObject);
            GameObject.FindObjectOfType<PlayerController>().startEndSceneAnim();
            GameObject.FindObjectOfType<LevelManagerEndingScene>().TheEnd();
        }
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(ArrowUpKey, transform.position, transform.rotation, gameObject.transform);
        }
        isPlayerIn = true;
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(transform.childCount > 0)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        } 
        isPlayerIn = false;   
    }
}
