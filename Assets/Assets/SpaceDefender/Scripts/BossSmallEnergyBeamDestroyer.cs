using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSmallEnergyBeamDestroyer : MonoBehaviour
{
    public GameObject BeamParent;
    private int ColliderFrame;
    private Animation anim;

    private void Awake() 
    {
        anim = GetComponent<Animation>();
    }
    private void Update() 
    {
        ColliderFrameChange();
    }
    private void FixedUpdate() 
    {
        //Destroy(gameObject, 1.750f);
    }
    private void ColliderFrameChange()
    {
        //1.750F - small beam
        //21 frames (1 / 21 = 0.0476190476190476)
        if(anim["LeftBeamAnim"].normalizedTime >=0f
            && anim["LeftBeamAnim"].normalizedTime < 0.047f)
        {
            ColliderFrame = 0;
            SwitchCollider();
        }
        else if(anim["LeftBeamAnim"].normalizedTime >=0.047f
            && anim["LeftBeamAnim"].normalizedTime < 0.095f)
        {
            ColliderFrame = 1;
            SwitchCollider();
        }
            else if(anim["LeftBeamAnim"].normalizedTime >=0.047f
            && anim["LeftBeamAnim"].normalizedTime < 0.095f)
        {
            ColliderFrame = 2;
            SwitchCollider();
        }
            else if(anim["LeftBeamAnim"].normalizedTime >=0.095f
            && anim["LeftBeamAnim"].normalizedTime < 0.142f)
        {
            ColliderFrame = 3;
            SwitchCollider();
        }
            else if(anim["LeftBeamAnim"].normalizedTime >=0.142f
            && anim["LeftBeamAnim"].normalizedTime < 0.190f)
        {
            ColliderFrame = 4;
            SwitchCollider();
        }
            else if(anim["LeftBeamAnim"].normalizedTime >=0.190f
            && anim["LeftBeamAnim"].normalizedTime < 0.238f)
        {
            ColliderFrame = 5;
            SwitchCollider();
        }
            else if(anim["LeftBeamAnim"].normalizedTime >=0.238f
            && anim["LeftBeamAnim"].normalizedTime < 0.285f)
        {
            ColliderFrame = 6;
            SwitchCollider();
        }
        else if(anim["LeftBeamAnim"].normalizedTime >=0.285f
            && anim["LeftBeamAnim"].normalizedTime < 0.333f)
        {
            ColliderFrame = 7;
            SwitchCollider();
        }
        else if(anim["LeftBeamAnim"].normalizedTime >=0.333f
            && anim["LeftBeamAnim"].normalizedTime < 0.380f)
        {
            ColliderFrame = 8;
            SwitchCollider();
        }
        else if(anim["LeftBeamAnim"].normalizedTime >=0.380f
            && anim["LeftBeamAnim"].normalizedTime < 0.428f)
        {
            ColliderFrame = 9;
            SwitchCollider();
        }
        else if(anim["LeftBeamAnim"].normalizedTime >=0.428f
            && anim["LeftBeamAnim"].normalizedTime < 0.476f)
        {
            ColliderFrame = 10;
            SwitchCollider();
        }
        else if(anim["LeftBeamAnim"].normalizedTime >=0.8095f)
        {
            ColliderFrame = 12;
            SwitchCollider();
        }
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
