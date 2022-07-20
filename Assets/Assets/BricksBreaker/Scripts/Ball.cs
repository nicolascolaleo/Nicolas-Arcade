using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool onlyOnStartGame;
    public GameObject ball, playerPaddle;
    Rigidbody2D rb;
    private float speed = 350f;
    void Start()
    {
        if(onlyOnStartGame == true)
        {
        Invoke(nameof(StartMovement), 2.9f);
        onlyOnStartGame = false;
        }
        else
        {
            RegularMovement();
        }
    }

    void Update()
    {   
        BallBounds();
        if(transform.position.y < playerPaddle.transform.position.y)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void StartMovement()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        this.rb.AddForce(force.normalized * this.speed);
    }
    private void RegularMovement()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.5f, 0.5f);
        force.y = Random.Range(-1f, 1f);
        this.rb.AddForce(force.normalized * this.speed);
    }

    private void BallBounds()
    {
        if(transform.position.y <= -4.8f)
        {
            Destroy(gameObject);
        }
    }
    public void DuplicateBuff()
    {
        Instantiate(ball, transform.position, transform.rotation);
    }
}

