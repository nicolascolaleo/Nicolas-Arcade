using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Sprite rightSprite, leftSprite, staticSprite;
    public GameObject leftSpriteShoot, rightSpriteShoot, staticSpriteShoot, player, projectile, projectileClone, explosion;
    public AudioClip projectileSound;
    private bool projectileReload, callDestroyOnce;
    private float timer = 0.3f;
    public int speed = 5;
    private void Awake() 
    {
        projectileReload = false;
        callDestroyOnce = true;
    }
    void Update()
    {
        PlayerBounds();
        PlayerMovement();
        FireProjectile();
    
        if(projectileReload == true)
        {
        timer -= Time.deltaTime;
        if(timer <=0)
        {
            timer = 0.3f;
            projectileReload = false;
        }
        }
    }

    void PlayerBounds()
    {
        if(transform.position.x >= 4.597991f)
        {
            transform.position = (new Vector3(4.597991f, transform.position.y, 0));
        }

        if(transform.position.x <= -4.611868f)
        {
            transform.position = (new Vector3(-4.611868f, transform.position.y, 0));
        }

       if(transform.position.y >= 3.977045f)
       {
           transform.position = new Vector3(transform.position.x, 3.977045f, 0);
       }

       if(transform.position.y <= -3.983233f)
       {
           transform.position = new Vector3(transform.position.x, -3.983233f, 0);
       }

    }

    void PlayerMovement()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(speed * Time.deltaTime,0));
            this.gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            this.gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
        }
        else if(!Input.anyKey)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = staticSprite;
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector2(0, speed * Time.deltaTime));
            this.gameObject.GetComponent<SpriteRenderer>().sprite = staticSprite;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector2(0, -speed * Time.deltaTime));
            this.gameObject.GetComponent<SpriteRenderer>().sprite = staticSprite;
        }
    }

    void FireProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space) 
            && projectileReload == false
            && GameObject.FindObjectOfType<CountDownTimer>().StopShootingAndAsteroids == false)
        {
            projectileClone = Instantiate(projectile, new Vector2(player.transform.position.x,player.transform.position.y + 0.75f),player.transform.rotation) as GameObject;
            SoundManager.instance.PlaySFX(projectileSound);
            
            if(this.gameObject.GetComponent<SpriteRenderer>().sprite == leftSprite)
                {
                    (Instantiate(leftSpriteShoot,new Vector2(player.transform.position.x, player.transform.position.y + 0.5f),player.transform.rotation)).transform.parent = player.transform;
                }
            else if(this.gameObject.GetComponent<SpriteRenderer>().sprite == rightSprite)
                {
                    (Instantiate(rightSpriteShoot,new Vector2(player.transform.position.x, player.transform.position.y + 0.5f),player.transform.rotation)).transform.parent = player.transform;                   
                }
            else if(this.gameObject.GetComponent<SpriteRenderer>().sprite == staticSprite) 
                {
                    (Instantiate(staticSpriteShoot,new Vector2(player.transform.position.x, player.transform.position.y + 0.5f),player.transform.rotation)).transform.parent = player.transform;
                }
            projectileReload = true;
        }
        
    }
        private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "enemy" 
            && callDestroyOnce == true
            && GameObject.FindObjectOfType<CountDownTimer>().StopShootingAndAsteroids == false 
            || 
            other.gameObject.tag == "alien" 
            && callDestroyOnce == true
            && GameObject.FindObjectOfType<CountDownTimer>().StopShootingAndAsteroids == false 
            ||
            other.gameObject.tag == "Boss"
            && callDestroyOnce == true
            && GameObject.FindObjectOfType<CountDownTimer>().StopShootingAndAsteroids == false)
        {
            Debug.Log(GameObject.FindObjectOfType<CountDownTimer>().StopShootingAndAsteroids);
            callDestroyOnce = false;
            Instantiate(explosion, player.transform.position, transform.rotation);
            GameObject.FindObjectOfType<LifePointScript>().CallPlayerRespawn();
            Destroy(gameObject);
        }
    }
}
