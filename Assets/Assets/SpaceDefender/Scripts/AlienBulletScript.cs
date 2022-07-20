using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletScript : MonoBehaviour
{
    public Transform AlienBullet;
    public GameObject explosion;
    private int bulletHp = 2;
    void Update()
    {
        transform.Translate(new Vector3(0, -4 * Time.deltaTime, 0));

        if(transform.position.y <= -5.75f)
        {
           Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(explosion, AlienBullet.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "projectile")
        {
            bulletHp--;
            if(bulletHp == 0)
            {
                Instantiate(explosion, AlienBullet.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
    

}
