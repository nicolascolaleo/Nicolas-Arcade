using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCast : MonoBehaviour
{
    public bool isDetecting;
    private float BoxLength = 1.8f;
    private float boxHeight = 1f;
    Vector2 boxVector;
    private void Awake() 
    {
        boxVector = new Vector2(BoxLength, boxHeight);
    }
    private void Update() 
    {
        DetectionOther();
    }

    private void OnDrawGizmos() 
    {
        if(isDetecting == true)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.yellow;
        }
        Gizmos.DrawWireCube(transform.position, boxVector);
    }
    private void DetectionOther()
    {
        int mask = LayerMask.GetMask("AlienLayer");
        var hitCollider = Physics2D.OverlapBox(transform.position, boxVector, mask);
        if (hitCollider && hitCollider.gameObject.CompareTag("alien") && hitCollider.gameObject != gameObject)
        {
           // Debug.Log(gameObject.name);
            isDetecting = true;
        }
        else
        {
            isDetecting = false;
        }
    }
}
