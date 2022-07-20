using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBallScript : MonoBehaviour
{
    public Transform Pos1, Pos2, StartPos;
    public float Speed;
    Vector3 nextPos;
    Vector3 upwardsDirection = new Vector3(0,0,0);
    Vector3 downwardsDirection = new Vector3(0,0,180);
    private bool isScreenMoving;
    // Start is called before the first frame update
    void Awake()
    {
        nextPos = StartPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        bool isScreenMoving = GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<MovingPlatforms>().isScreenMoving;
        if (isScreenMoving == false)
        {
            MovingAcidBall();
        }
        
    }

        void MovingAcidBall()
    {
        if(transform.position == Pos1.position)
        {
            transform.eulerAngles = upwardsDirection;
            nextPos = Pos2.position;
        }
        if(transform.position == Pos2.position)
        {
            transform.eulerAngles = downwardsDirection;
            nextPos = Pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, Speed * Time.deltaTime);
    }
}
