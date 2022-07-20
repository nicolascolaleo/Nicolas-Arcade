using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBrick : MonoBehaviour
{
    private int health = 2;
    public Sprite bricked;
    public ParticleSystem destroyEffect;
    public GameObject extendBuff, duplicateBallsBuff;
    int RandomNumber;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Ball")
        {
            health--;
            if(health == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bricked;
            }
            else if(health <= 0)
            {
                RandomNumber = Random.Range(0,5);
                Debug.Log(RandomNumber);
                BrickDestroyEffect();
                Destroy(gameObject);
                if(RandomNumber == 1)
                {
                    Instantiate(extendBuff, transform.position, transform.rotation);
                }
                else if(RandomNumber == 2)
                {
                    Instantiate(duplicateBallsBuff, transform.position, transform.rotation);
                }
            }
        }
    }
    private void BrickDestroyEffect()
    {
        Vector2 brickPos = gameObject.transform.position;
        Vector2 spawnPos = new Vector2(brickPos.x, brickPos.y);
        GameObject effect = Instantiate(destroyEffect.gameObject, spawnPos, Quaternion.identity);

        Destroy(effect, destroyEffect.main.startLifetime.constant);
    }
}
