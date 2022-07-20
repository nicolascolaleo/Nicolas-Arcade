using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideAnimationsScript : MonoBehaviour
{
    private Animator anim;
    private void Awake() 
    {
    anim = GetComponent<Animator>();
    }
    private void FixedUpdate() 
    {
        MoveRight();
    }
    private void MoveRight()
    {
        transform.position += new Vector3(0.3f,0, 0) *Time.fixedDeltaTime;
        if(transform.localPosition.x > 2.8f)
        {
            transform.localPosition = new Vector2(-3f, 3.05f);
        }

        /*if(transform.localPosition.x > 2.8f
            && gameObject.GetComponent<Animator>().GetInteger("SideAnimNum") == 0)
        {
            transform.localPosition = new Vector2(-3f, 3.05f);
        }
        else if(transform.localPosition.x > 2.85f
                && gameObject.GetComponent<Animator>().GetInteger("SideAnimNum") == 1)
        {
            transform.localPosition = new Vector2(-3f, 5.55f);
        }
        else if(transform.localPosition.x > 2.8f
        && gameObject.GetComponent<Animator>().GetInteger("SideAnimNum") == 2)
        {
            transform.localPosition = new Vector2(-3f, 6.73f);
        }
        else if(transform.localPosition.x > 2.85f
        && gameObject.GetComponent<Animator>().GetInteger("SideAnimNum") == 3)
        {
            transform.localPosition = new Vector2(-3f, 5.79f);
        }*/
    }

    public void ChangeToSpaceDefenderSideAnim()
    {
        anim.SetInteger("SideAnimNum", 0);
    }
    public void ChangeToDaveSideAnim()
    {
        anim.SetInteger("SideAnimNum", 1);
    }
    public void ChangeToQuizGameSideAnim()
    {
        anim.SetInteger("SideAnimNum", 2);
    }
    public void ChangeToBrickBreakerSideAnim()
    {
        anim.SetInteger("SideAnimNum", 3);
    }
}
