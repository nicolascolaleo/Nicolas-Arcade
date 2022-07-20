using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour
{
    public AudioClip deathSFX;
    private void Awake() 
    {
        SoundManager.instance.PlaySFX(deathSFX);
    }
    private void FixedUpdate() 
    {
        Destroy(gameObject, 0.662f);
    }
}
