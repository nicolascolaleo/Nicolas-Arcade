using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAfterSpawnEffect : MonoBehaviour
{
    public GameObject Alien;
    public void AfterSpawnAlien()
    {
        Instantiate(Alien, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
    }

}
