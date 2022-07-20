using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScreenScript : MonoBehaviour
{
    private GameObject Player;
    public GameObject ArcadeMachine;
    Vector3 PlayerPointScreenTwo;
    Vector3 arcadeScreenTwo;
    Vector3 Playerstart;
    Vector3 arcadeStart;
    float lerpTime = 0.0f;
    float speed = 4f;
    public bool ChangeToNextScreen = false;
    private bool firstScreen, secondScreen, thirdScreen, fourthScreen, fifthScreen;
    public Transform RespawnPoint;
    
    private void Awake() 
    {
    secondScreen = false;
    thirdScreen = false;
    fourthScreen = false;
    fifthScreen = false;
    }

    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if(ArcadeMachine.transform.position != arcadeScreenTwo && Player != null)
        {
            ScreenTransition();
            if(ChangeToNextScreen == true)
            {
                Player.GetComponent<PlayerController>().PlayerControl = false;
                Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<MovingPlatforms>().isScreenMoving = true;

                Player.transform.position = Vector2.MoveTowards(Playerstart, PlayerPointScreenTwo, lerpTime);
                ArcadeMachine.transform.position = Vector3.MoveTowards(arcadeStart, arcadeScreenTwo,lerpTime);
                if(lerpTime >= 1.0f)
                {
                    ChangeToNextScreen = false;
                }
                else
                {
                    lerpTime += speed * Time.deltaTime;
                }
            }
        }
        if(Player != null)
        {
            CheckScreenPos();
        }
    }
    void ScreenTransition() 
        {
            //first screen transition
            if(Player.transform.position.x >= 4.8f 
                && ChangeToNextScreen == false && firstScreen == true)
            {
                ChangeToNextScreen = true;

                Playerstart = Player.transform.position;
                arcadeStart = ArcadeMachine.transform.localPosition;

                PlayerPointScreenTwo = new Vector3 (5.9f, Playerstart.y,Playerstart.z);

                lerpTime = 0.0f;
            }
             //second screen transition
            else if(Player.transform.position.x >= 15.1f 
                    && ChangeToNextScreen == false 
                    && secondScreen == true)
            {
                ChangeToNextScreen = true;

                Playerstart = Player.transform.position;
                arcadeStart = ArcadeMachine.transform.localPosition;

                PlayerPointScreenTwo = new Vector3 (16.2f, Playerstart.y,Playerstart.z);

                lerpTime = 0.0f;
            }
            //third screen transition
            else if(Player.transform.position.x >= 25.3f && ChangeToNextScreen == false 
                    && thirdScreen == true)
                {
                ChangeToNextScreen = true;

                Playerstart = Player.transform.position;
                arcadeStart = ArcadeMachine.transform.localPosition;

                PlayerPointScreenTwo = new Vector3 (26.5f, Playerstart.y,Playerstart.z);

                lerpTime = 0.0f;
            }
            //forth screen transition
            else if(Player.transform.position.x >= 35.6f 
                    && ChangeToNextScreen == false 
                    && fourthScreen == true)
                {
                ChangeToNextScreen = true;

                Playerstart = Player.transform.position;
                arcadeStart = ArcadeMachine.transform.localPosition;

                PlayerPointScreenTwo = new Vector3 (36.4f, Playerstart.y,Playerstart.z);

                lerpTime = 0.0f;
                }
            // fifth screen transition
            else if(Player.transform.position.x >= 45.8f 
                    && ChangeToNextScreen == false
                    && fifthScreen == true)
                {
                ChangeToNextScreen = true;

                Playerstart = Player.transform.position;
                arcadeStart = ArcadeMachine.transform.localPosition;

                PlayerPointScreenTwo = new Vector3 (46.6f, Playerstart.y,Playerstart.z);

                lerpTime = 0.0f;
                }
            
        }
        void CheckScreenPos()
        {
            //start screen
            if(ArcadeMachine.transform.position.x < 10.24f)
            {
                firstScreen = true;
                secondScreen = false;
                arcadeScreenTwo = new Vector3(10.24f,0,-1);
            }
            //first screen
            else if(ArcadeMachine.transform.position.x >= 10.24f 
                    && Player.transform.position.x <= 5.9f)
            {
            Player.GetComponent<PlayerController>().PlayerControl = true;
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<MovingPlatforms>().isScreenMoving = false;

                firstScreen = false;
                secondScreen = true;
                ChangeToNextScreen = false;
                arcadeScreenTwo = new Vector3(20.48f,0,-1);
            }
            //second screen
            else if(ArcadeMachine.transform.position.x >= 20.48f 
                    && Player.transform.position.x <= 16.2f)
            {
            Player.GetComponent<PlayerController>().PlayerControl = true;
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<MovingPlatforms>().isScreenMoving = false;

                secondScreen = false;
                thirdScreen = true;
                ChangeToNextScreen = false;
                arcadeScreenTwo = new Vector3(30.72f,0,-1);
            }
            //third screen
            else if(ArcadeMachine.transform.position.x >= 30.72f 
                    && Player.transform.position.x <= 26.5f)
            {
            Player.GetComponent<PlayerController>().PlayerControl = true;
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<MovingPlatforms>().isScreenMoving = false;

                thirdScreen = false;
                fourthScreen = true;
                ChangeToNextScreen = false;
                arcadeScreenTwo = new Vector3(40.96f,0,-1);
            }
            // fourth screen
            else if(ArcadeMachine.transform.position.x >= 40.96f 
                     && Player.transform.position.x <= 36.4f)
            {
            Player.GetComponent<PlayerController>().PlayerControl = true;
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<MovingPlatforms>().isScreenMoving = false;

                fourthScreen = false;
                fifthScreen = true;
                ChangeToNextScreen = false;
                arcadeScreenTwo = new Vector3(51.2f,0,-1);
            }
            // fifth screen
            else if(ArcadeMachine.transform.position.x >= 51.2f 
                     && Player.transform.position.x <= 46.6f)
                    {
                        Player.GetComponent<PlayerController>().PlayerControl = true;
                        Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                        GameObject.FindGameObjectWithTag("MovingPlatform").GetComponent<MovingPlatforms>().isScreenMoving = false;
                        fifthScreen = false;
                        ChangeToNextScreen = false;
                    }
        }
}
