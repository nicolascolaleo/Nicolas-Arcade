using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 6.3f;
    public bool playerMove;

    //Growth 
    private float timer1, timer2;
    private float growthTime = 2.5f;
    private float maxSize = 1.25f;
    private bool isMaxSize;
    private void Awake() 
    {
        playerMove = true;
        isMaxSize = true;
    }
    void Update()
    {
        if(playerMove == true)
        {
            PlayerMovement();
        }

        if (isMaxSize == false)
        {
            StartCoroutine(Grow());
        }
        
    }

    private void PlayerMovement()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 hitPoint = collision.contacts[0].point;
            Vector2 paddleCenter = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            ballRb.velocity = Vector2.zero;
            float difference = paddleCenter.x - hitPoint.x;

            if (hitPoint.x < paddleCenter.x)
            {
                ballRb.AddForce(new Vector3(-(Mathf.Abs(difference * 120)), 350f));
            }
            else
            {
                ballRb.AddForce(new Vector3((Mathf.Abs(difference * 120)), 350f));
            }
        }
        if(collision.gameObject.tag == "extendBuff")
        {
            timer1 = 0f;
            timer2 = 0f;
            isMaxSize = false;
        }
        if(collision.gameObject.tag == "DoubleBallBuff")
        {
            Debug.Log("collided with");
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach(GameObject oneBall in balls)
            {
                oneBall.GetComponent<Ball>().DuplicateBuff();
            }
        }
    }
    private IEnumerator Grow()
    {
        Vector2 startScale = transform.localScale;
        Vector2 maxScale = new Vector2(maxSize, 1);
        Vector2 minScale = new Vector2(1,1);
        do 
        {
            transform.localScale = Vector2.Lerp(startScale, maxScale, timer1 / growthTime);
            timer1 += Time.deltaTime;
            yield return null;
        }
        while(timer1 < growthTime);
        isMaxSize = true;
        growthTime = 2.5f;
        yield return new WaitForSeconds(9);
        do
        {
            transform.localScale = Vector2.Lerp(maxScale, minScale, timer2 / growthTime);
            timer2 += Time.deltaTime;
            yield return null;
        }
        while (timer2 < growthTime);
    }

}

