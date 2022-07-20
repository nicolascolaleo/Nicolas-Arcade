using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyOnCollision : MonoBehaviour
{
    public Transform Bullet;
    public GameObject bulletExplosion;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "enemy" || other.gameObject.tag == "alien" || other.gameObject.tag == "Boss")
        {
            Instantiate(bulletExplosion, Bullet.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
