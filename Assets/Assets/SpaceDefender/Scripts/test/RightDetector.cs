using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDetector : MonoBehaviour
{
    public bool IsRightDetect;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("detectors"))
        {
            IsRightDetect = true;
           // Debug.Log("is right detected" + IsRightDetect);
        }

    }  
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("detectors"))
        {
            IsRightDetect = false;
           // Debug.Log("is right detected" + IsRightDetect);
        }
    }
}
