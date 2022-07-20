using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningHeartScript : MonoBehaviour
{
    private Animator SpinHeart;
    void Awake()
    {
        SpinHeart = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        IsHealthLow();
    }

    private void IsHealthLow()
    {
        if(GameObject.Find("LifePointsHealthPoints").GetComponent<DaveHealthPoints>().HealthPoints <= 1)
        {
            SpinHeart.SetBool("IsHealthLowerThan", true);
        }
        else
        {
            SpinHeart.SetBool("IsHealthLowerThan", false);
        }
    }
}
