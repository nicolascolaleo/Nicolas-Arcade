using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveHealthPoints : MonoBehaviour
{
    public int HealthPoints = 3;
    private Animator HealthPointAnim;

    private void Awake() 
    {
        HealthPointAnim = GetComponent<Animator>();
    }
    void Update()
    {
        CheckPlayerHealth();
    }

    private void CheckPlayerHealth()
    {
        if(HealthPoints == 3)
        {
            HealthPointAnim.SetInteger("LifePoints", 3);
        }
        else if(HealthPoints == 2)
        {
            HealthPointAnim.SetInteger("LifePoints", 2);
        }
        else if(HealthPoints == 1)
        {
            HealthPointAnim.SetInteger("LifePoints", 1);
        }
        else if(HealthPoints == 0)
        {
            HealthPointAnim.SetInteger("LifePoints", 0);
        }

    }
}
