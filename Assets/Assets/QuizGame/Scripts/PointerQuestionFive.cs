using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerQuestionFive : MonoBehaviour
{
    public GameObject Correct, Wrong, Pointer;
    public Sprite QuestionFiveAnswerOneClick,QuestionFiveAnswerOne,
                QuestionFiveAnswerTwoClick, QuestionFiveAnswerTwo,
                QuestionFiveAnswerThreeClick, QuestionFiveAnswerThree,
                QuestionFiveAnswerFourClick, QuestionFiveAnswerFour;
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
           GameObject.Find("QuestionFiveAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionFiveAnswerOneClick;
           GameObject.Find("QuestionFiveAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.4f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 2.5f || GameObject.Find("QuestionFiveAnswerOne").GetComponent<SpriteRenderer>().sprite == QuestionFiveAnswerOneClick && transform.position.y != 2.5f)
        {
        GameObject.Find("QuestionFiveAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionFiveAnswerOne;
        GameObject.Find("QuestionFiveAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == 0.5f)
        {
           GameObject.Find("QuestionFiveAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionFiveAnswerTwoClick;
           GameObject.Find("QuestionFiveAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.4f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 0.5f ||  GameObject.Find("QuestionFiveAnswerTwo").GetComponent<SpriteRenderer>().sprite == QuestionFiveAnswerTwoClick && transform.position.y != 0.5f )
        {
        GameObject.Find("QuestionFiveAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionFiveAnswerTwo;
        GameObject.Find("QuestionFiveAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -1.5f)
        {
           GameObject.Find("QuestionFiveAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionFiveAnswerThreeClick;
           GameObject.Find("QuestionFiveAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.6f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -1.5f || GameObject.Find("QuestionFiveAnswerThree").GetComponent<SpriteRenderer>().sprite == QuestionFiveAnswerThreeClick && transform.position.y != -1.5f)
        {
        GameObject.Find("QuestionFiveAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionFiveAnswerThree;
        GameObject.Find("QuestionFiveAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -3.5f)
        {
           GameObject.Find("QuestionFiveAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionFiveAnswerFourClick;
           GameObject.Find("QuestionFiveAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.6f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -3.5f ||GameObject.Find("QuestionFiveAnswerFour").GetComponent<SpriteRenderer>().sprite == QuestionFiveAnswerFourClick && transform.position.y != -3.5f )
        {
        GameObject.Find("QuestionFiveAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionFiveAnswerFourClick;
        GameObject.Find("QuestionFiveAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.5f);
        Instantiate(Correct, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
    }  
}
