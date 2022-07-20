using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerQuestionTwo : MonoBehaviour
{
    public GameObject Correct, Wrong, Pointer;
    public Sprite QuestionTwoAnswerOneClick, QuestionTwoAnswerOne,
                QuestionTwoAnswerTwoClick, QuestionTwoAnswerTwo,
                QuestionTwoAnswerThreeClick, QuestionTwoAnswerThree,
                QuestionTwoAnswerFourClick, QuestionTwoAnswerFour;
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
           GameObject.Find("QuestionTwoAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionTwoAnswerOneClick;
           GameObject.Find("QuestionTwoAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.4f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 2.5f || GameObject.Find("QuestionTwoAnswerOne").GetComponent<SpriteRenderer>().sprite == QuestionTwoAnswerOneClick && transform.position.y != 2.5f)
        {
        GameObject.Find("QuestionTwoAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionTwoAnswerOne;
        GameObject.Find("QuestionTwoAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == 0.5f)
        {
           GameObject.Find("QuestionTwoAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionTwoAnswerTwoClick;
           GameObject.Find("QuestionTwoAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.4f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 0.5f ||  GameObject.Find("QuestionTwoAnswerTwo").GetComponent<SpriteRenderer>().sprite == QuestionTwoAnswerTwoClick && transform.position.y != 0.5f )
        {
        GameObject.Find("QuestionTwoAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionTwoAnswerTwo;
        GameObject.Find("QuestionTwoAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -1.5f)
        {
           GameObject.Find("QuestionTwoAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionTwoAnswerThreeClick;
           GameObject.Find("QuestionTwoAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.6f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -1.5f || GameObject.Find("QuestionTwoAnswerThree").GetComponent<SpriteRenderer>().sprite == QuestionTwoAnswerThreeClick && transform.position.y != -1.5f)
        {
        GameObject.Find("QuestionTwoAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionTwoAnswerThree;
        GameObject.Find("QuestionTwoAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.5f);
        Instantiate(Correct, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -3.5f)
        {
           GameObject.Find("QuestionTwoAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionTwoAnswerFourClick;
           GameObject.Find("QuestionTwoAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.6f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -3.5f ||GameObject.Find("QuestionTwoAnswerFour").GetComponent<SpriteRenderer>().sprite == QuestionTwoAnswerFourClick && transform.position.y != -3.5f )
        {
        GameObject.Find("QuestionTwoAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionTwoAnswerFour;
        GameObject.Find("QuestionTwoAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
    }   
}
