using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLoadScript : MonoBehaviour
{
    public GameObject CreditsPrefab;
    public Renderer Renderer;
    public Color Color;
    private bool clickonce;

    private void Awake()
    {
        clickonce = false;
        Renderer = gameObject.GetComponent<Renderer>();
        Renderer.material.color = Color; 
        StartCoroutine(FadeIn());
    }


    void Update()
    {
    if(Input.GetKeyDown(KeyCode.Return)
        && clickonce == false)
        {
            clickonce = true;
            Instantiate(CreditsPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator FadeIn()
    {
        Debug.Log("started");
        do
        {
            Color.a += 0.25f * Time.fixedDeltaTime; //was 0.0025 before fixeddeltatime
            Renderer.material.color = Color;
            yield return null;
        }
        while(Color.a <= 1f);
    }
}
