using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxStarsPrefabScript : MonoBehaviour
{
    public GameObject TheEndPrefab;
    public void ChildrenEnableAnim()
    {
        StartCoroutine(delayBeforeSequence());
    }
    private IEnumerator delayBeforeSequence()
    {
        yield return new WaitForSeconds(5f);
        foreach(Transform child in transform)
        {
            child.GetComponent<bgScroller>().EnablePallaxAnim();
           // Debug.Log(child);
        }
        yield return new WaitForSeconds(3f);
        GameObject.FindObjectOfType<ReloadEffects>().FadeOutBlack();
        yield return new WaitForSeconds(5f);
        Instantiate(TheEndPrefab, new Vector2(0f,2f),transform.rotation);
        Destroy(gameObject);
    }
}
