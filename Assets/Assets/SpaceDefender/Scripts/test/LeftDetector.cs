using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDetector : MonoBehaviour
{
    public bool IsLeftDetected;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("detectors"))
        {
            IsLeftDetected = true;
           // Debug.Log("is left detected" + IsLeftDetected);
        }

    }  
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("detectors"))
        {
            IsLeftDetected = false;
          //  Debug.Log("is left detected" + IsLeftDetected);
        }
    }
}
