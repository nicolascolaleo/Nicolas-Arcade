using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointerControl : MonoBehaviour
{
    public GameObject Correct, Wrong, Pointer;
    public Sprite QuestionOneAnswerOneClick, QuestionOneAnswerOne,
                QuestionOneAnswerTwoClick, QuestionOneAnswerTwo,
                QuestionOneAnswerThreeClick, QuestionOneAnswerThree,
                QuestionOneAnswerFourClick, QuestionOneAnswerFour;
    void Update()
    {
        PointerMovement();
        PointerClickEffect();
    }

    private void PointerMovement()
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
    private void PointerClickEffect()
    {
        if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == 2.5f)
        {
           GameObject.Find("QuestionOneAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionOneAnswerOneClick;
           GameObject.Find("QuestionOneAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.4f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 2.5f || GameObject.Find("QuestionOneAnswerOne").GetComponent<SpriteRenderer>().sprite == QuestionOneAnswerOneClick && transform.position.y != 2.5f)
        {
        GameObject.Find("QuestionOneAnswerOne").GetComponent<SpriteRenderer>().sprite = QuestionOneAnswerOne;
        GameObject.Find("QuestionOneAnswerOne").GetComponent<Transform>().position = new Vector2(0,2.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == 0.5f)
        {
           GameObject.Find("QuestionOneAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionOneAnswerTwoClick;
           GameObject.Find("QuestionOneAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.4f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == 0.5f ||  GameObject.Find("QuestionOneAnswerTwo").GetComponent<SpriteRenderer>().sprite == QuestionOneAnswerTwoClick && transform.position.y != 0.5f )
        {
        GameObject.Find("QuestionOneAnswerTwo").GetComponent<SpriteRenderer>().sprite = QuestionOneAnswerTwo;
        GameObject.Find("QuestionOneAnswerTwo").GetComponent<Transform>().position = new Vector2(0,0.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -1.5f)
        {
           GameObject.Find("QuestionOneAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionOneAnswerThreeClick;
           GameObject.Find("QuestionOneAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.6f);
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -1.5f || GameObject.Find("QuestionOneAnswerThree").GetComponent<SpriteRenderer>().sprite == QuestionOneAnswerThreeClick && transform.position.y != -1.5f)
        {
        GameObject.Find("QuestionOneAnswerThree").GetComponent<SpriteRenderer>().sprite = QuestionOneAnswerThree;
        GameObject.Find("QuestionOneAnswerThree").GetComponent<Transform>().position = new Vector2(0,-1.5f);
        Instantiate(Correct, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && transform.position.y == -3.5f)
        {
           GameObject.Find("QuestionOneAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionOneAnswerFourClick;
           GameObject.Find("QuestionOneAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.6f);  
        }
        else if(Input.GetKeyUp(KeyCode.Space) && transform.position.y == -3.5f ||GameObject.Find("QuestionOneAnswerFour").GetComponent<SpriteRenderer>().sprite == QuestionOneAnswerFourClick && transform.position.y != -3.5f )
        {
        GameObject.Find("QuestionOneAnswerFour").GetComponent<SpriteRenderer>().sprite = QuestionOneAnswerFour;
        GameObject.Find("QuestionOneAnswerFour").GetComponent<Transform>().position = new Vector2(0,-3.5f);
        Instantiate(Wrong, new Vector2(0,0), transform.rotation);
        Destroy(gameObject);
        }
    }    
}