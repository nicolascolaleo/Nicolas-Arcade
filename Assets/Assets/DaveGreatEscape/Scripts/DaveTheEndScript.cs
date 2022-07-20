using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveTheEndScript : MonoBehaviour
{
    private bool clickOnce;
    public GameObject ResetOrQuitAnim;
    public Color Color;
    public Renderer Renderer;

    void Start()
    {
        clickOnce = false;
        Renderer = gameObject.GetComponent<Renderer>();
        Renderer.material.color = Color;
        StartCoroutine(TheEnd());
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Return)
        && clickOnce == true)
        {
            Debug.Log("clicked");
            clickOnce = false;
            GameObject.FindObjectOfType<ArcadeCallToEnd>().EndGame();
        }
    }

    private IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(4.0f);
        do
        {
            Color.a += 0.15f * Time.fixedDeltaTime;
            Renderer.material.color = Color;
            yield return null;
        }
        while(Color.a <= 1f);
        Instantiate(ResetOrQuitAnim, new Vector2(10.5f,-3), transform.rotation);
        clickOnce = true;
    }
}
