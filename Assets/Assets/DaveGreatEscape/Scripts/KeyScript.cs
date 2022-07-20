using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject UI;
    public GameObject KeyEarn;
    public AudioClip KeySFX;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate (KeyEarn, new Vector2(UI.transform.position.x + 4.3f, UI.transform.position.y), Quaternion.identity, UI.transform);
            SoundManager.instance.PlaySFX(KeySFX);
            GameObject.FindObjectOfType<LevelManager>().IsKeyEarned = true;
            Destroy(gameObject);
        }
    }
}
