using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour
{
    public GameObject ArrowUpKey,TextBoxOne, TextBoxTwo;
    private Vector2 arrowPos, textBoxPos;
    private void Start() 
    {
        arrowPos = new Vector2(gameObject.transform.position.x -0.02f, gameObject.transform.position.y + 0.7f);
        textBoxPos = new Vector2(gameObject.transform.position.x, transform.position.y + 2.2f);
    }

        private void Update() 
    {
            if(gameObject.name == "SignTwo"
                && transform.childCount > 0 
                && Input.GetKeyDown(KeyCode.UpArrow)
                && transform.Find("TestBoxTwo(Clone)") == null)
            {
                Destroy(gameObject.transform.GetChild(0).gameObject);
                Instantiate(TextBoxTwo, textBoxPos ,transform.rotation, gameObject.transform);
            }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(ArrowUpKey, arrowPos, transform.rotation, gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }
}
