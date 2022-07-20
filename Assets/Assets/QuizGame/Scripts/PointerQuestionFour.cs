using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerQuestionFour : MonoBehaviour
{
    public GameObject Correct, Wrong, Pointer;
    public Sprite QuestionFourAnswerOneClick, QuestionFourAnswerOne,
                QuestionFourAnswerTwoClick, QuestionFourAnswerTwo,
                QuestionFourAnswerThreeClick, QuestionFourAnswerThree,
                QuestionFourAnswerFourClick, QuestionFourAnswerFour;
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
           GameObject.Find("QuestionFourAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionFourAnswerOneClick;
           GameObject.Find("QuestionFourAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.4f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 2.5f || GameObject.Find("QuestionFourAnswerOne").GetComponent<SpriteRenderer>().sprite == QuestionFourAnswerOneClick && transform.position.y != 2.5f)
        {
        GameObject.Find("QuestionFourAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionFourAnswerOne;
        GameObject.Find("QuestionFourAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == 0.5f)
        {
           GameObject.Find("QuestionFourAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionFourAnswerTwoClick;
           GameObject.Find("QuestionFourAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.4f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 0.5f ||  GameObject.Find("QuestionFourAnswerTwo").GetComponent<SpriteRenderer>().sprite == QuestionFourAnswerTwoClick && transform.position.y != 0.5f )
        {
        GameObject.Find("QuestionFourAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionFourAnswerTwo;
        GameObject.Find("QuestionFourAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -1.5f)
        {
           GameObject.Find("QuestionFourAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionFourAnswerThreeClick;
           GameObject.Find("QuestionFourAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.6f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -1.5f || GameObject.Find("QuestionFourAnswerThree").GetComponent<SpriteRenderer>().sprite == QuestionFourAnswerThreeClick && transform.position.y != -1.5f)
        {
        GameObject.Find("QuestionFourAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionFourAnswerFour;
        GameObject.Find("QuestionFourAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -3.5f)
        {
           GameObject.Find("QuestionFourAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionFourAnswerFourClick;
           GameObject.Find("QuestionFourAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.6f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -3.5f ||GameObject.Find("QuestionFourAnswerFour").GetComponent<SpriteRenderer>().sprite == QuestionFourAnswerFourClick && transform.position.y != -3.5f )
        {
        GameObject.Find("QuestionFourAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionFourAnswerFour;
        GameObject.Find("QuestionFourAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.5f);
        Instantiate(Correct, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
    }  
}
