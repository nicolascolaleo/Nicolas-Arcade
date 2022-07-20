using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAlienShootEffect : MonoBehaviour
{
    public Transform AlienShoot;
    public GameObject AlienBullet;
    private int shootOnce = 1;
    private void FixedUpdate()
    {
        if(shootOnce == 1)
        {
            Instantiate(AlienBullet, new Vector2 (AlienShoot.position.x, AlienShoot.position.y -0.5f), transform.rotation);
            shootOnce--;
        }
        Destroy(gameObject, 0.267f);
    }
}
