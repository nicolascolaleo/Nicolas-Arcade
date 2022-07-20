using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerQuestionThree : MonoBehaviour
{
    public GameObject Correct, Wrong, Pointer;
    public Sprite QuestionThreeAnswerOneClick, QuestionThreeAnswerOne,
                QuestionThreeAnswerTwoClick, QuestionThreeAnswerTwo,
                QuestionThreeAnswerThreeClick, QuestionThreeAnswerThree,
                QuestionThreeAnswerFourClick, QuestionThreeAnswerFour;
    void Update()
    {
        PointerMovement();
        PointerClickEffect();
    }

    void PointerMovement()
    {
       if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(transform.position.y == -3.5f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x,transform.position.y - 2f);
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(transform.position.y == 2.5f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x,transform.position.y + 2f);
            }
        }
    }
    void PointerClickEffect()
    {
        if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == 2.5f)
        {
           GameObject.Find("QuestionThreeAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionThreeAnswerOneClick;
           GameObject.Find("QuestionThreeAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.4f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 2.5f || GameObject.Find("QuestionThreeAnswerThree").GetComponent<SpriteRenderer>().sprite == QuestionThreeAnswerOneClick && transform.position.y != 2.5f)
        {
        GameObject.Find("QuestionThreeAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionThreeAnswerThree;
        GameObject.Find("QuestionThreeAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.5f);
        Instantiate(Correct, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == 0.5f)
        {
           GameObject.Find("QuestionThreeAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionThreeAnswerTwoClick;
           GameObject.Find("QuestionThreeAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.4f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 0.5f ||  GameObject.Find("QuestionThreeAnswerThree").GetComponent<SpriteRenderer>().sprite == QuestionThreeAnswerTwoClick && transform.position.y != 0.5f )
        {
        GameObject.Find("QuestionThreeAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionThreeAnswerTwo;
        GameObject.Find("QuestionThreeAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -1.5f)
        {
           GameObject.Find("QuestionThreeAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionThreeAnswerThreeClick;
           GameObject.Find("QuestionThreeAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.6f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -1.5f || GameObject.Find("QuestionThreeAnswerThree").GetComponent<SpriteRenderer>().sprite == QuestionThreeAnswerThreeClick && transform.position.y != -1.5f)
        {
        GameObject.Find("QuestionThreeAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionThreeAnswerThree;
        GameObject.Find("QuestionThreeAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -3.5f)
        {
           GameObject.Find("QuestionThreeAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionThreeAnswerFourClick;
           GameObject.Find("QuestionThreeAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.6f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -3.5f ||GameObject.Find("QuestionThreeAnswerFour").GetComponent<SpriteRenderer>().sprite == QuestionThreeAnswerFourClick && transform.position.y != -3.5f )
        {
        GameObject.Find("QuestionThreeAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionThreeAnswerFour;
        GameObject.Find("QuestionThreeAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
    }   
}
