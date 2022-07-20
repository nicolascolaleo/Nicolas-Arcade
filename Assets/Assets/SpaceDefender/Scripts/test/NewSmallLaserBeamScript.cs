using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSmallLaserBeamScript : MonoBehaviour
{
    public GameObject BeamParent;
    private int ColliderFrame;

    private void FixedUpdate() 
    {
        Destroy(gameObject, 1.750f);
    }
    private void FirstFrameCollider()
    {
        ColliderFrame = 0;
        SwitchCollider();
    }
    private void SecondFrameCollider()
    {
        ColliderFrame = 1;
        SwitchCollider();
    }
    private void ThirdFrameCollider()
    {
        ColliderFrame = 2;
        SwitchCollider();
    }
    private void ForthFrameCollider()
    {
        ColliderFrame = 3;
        SwitchCollider();
    }
    private void FifthFrameCollider()
    {
        ColliderFrame = 4;
        SwitchCollider();
    }
    private void SixthFrameCollider()
    {
        ColliderFrame = 5;
        SwitchCollider();
    }
    private void SeventhFrameCollider()
    {
        ColliderFrame = 6;
        SwitchCollider();
    }
    private void EighthFrameCollider()
    {
        ColliderFrame = 7;
        SwitchCollider();
    }
    private void NinthFrameCollider()
    {
        ColliderFrame = 8;
        SwitchCollider();
    }
    private void TenthFrameCollider()
    {
        ColliderFrame = 9;
        SwitchCollider();
    }
    private void FinalFrameCollider()
    {
        ColliderFrame = 10;
        SwitchCollider();
    }
    private void NoFrameCollider()
    {
        ColliderFrame = 11;
        SwitchCollider();
    }
    
    private void SwitchCollider()
    {
        switch(ColliderFrame)
        {
            case 0:
                BeamParent.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                BeamParent.transform.GetChild(0).gameObject.SetActive(false);
                BeamParent.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                BeamParent.transform.GetChild(1).gameObject.SetActive(false);
                BeamParent.transform.GetChild(2).gameObject.SetActive(true);
                break;     
            case 3:
                BeamParent.transform.GetChild(2).gameObject.SetActive(false);
                BeamParent.transform.GetChild(3).gameObject.SetActive(true);
                break;           
            case 4:
                BeamParent.transform.GetChild(3).gameObject.SetActive(false);
                BeamParent.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 5:
                BeamParent.transform.GetChild(4).gameObject.SetActive(false);
                BeamParent.transform.GetChild(5).gameObject.SetActive(true);
                break;
            case 6:
                BeamParent.transform.GetChild(5).gameObject.SetActive(false);
                BeamParent.transform.GetChild(6).gameObject.SetActive(true);
                break;
            case 7:
                BeamParent.transform.GetChild(6).gameObject.SetActive(false);
                BeamParent.transform.GetChild(7).gameObject.SetActive(true);
                break;
            case 8:
                BeamParent.transform.GetChild(7).gameObject.SetActive(false);
                BeamParent.transform.GetChild(8).gameObject.SetActive(true);
                break;
            case 9:
                BeamParent.transform.GetChild(8).gameObject.SetActive(false);
                BeamParent.transform.GetChild(9).gameObject.SetActive(true);
                break;
            case 10:
                BeamParent.transform.GetChild(9).gameObject.SetActive(false);
                BeamParent.transform.GetChild(10).gameObject.SetActive(true);
                break;
            default:
                BeamParent.transform.GetChild(10).gameObject.SetActive(false);
                break;
        }
    }
}
