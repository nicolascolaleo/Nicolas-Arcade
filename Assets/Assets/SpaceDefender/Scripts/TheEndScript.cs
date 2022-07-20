using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEndScript : MonoBehaviour
{
    public Color Color;
    public Renderer Renderer;

    void Start()
    {
        Renderer = gameObject.GetComponent<Renderer>();
        Renderer.material.color = Color;
        StartCoroutine(TheEnd());
    }

    private IEnumerator TheEnd()
    {
        do
        {
            Color.a += 0.1f * Time.fixedDeltaTime;
            Renderer.material.color = Color;
            yield return null;
        }
        while(Color.a <= 1f);
        GameObject.FindObjectOfType<GameOverSpaceDefenders>().OnlyIfWin();
    }
}
