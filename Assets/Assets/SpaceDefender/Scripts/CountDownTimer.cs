using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI CountDown;  
    private float startTime = 95f;
    public float currentTime , TickFaster;
    public bool StopTimer, BossTime, BossWon, StopShootingAndAsteroids;
    private bool isTimerDone;
    void Awake()
    {
        StopShootingAndAsteroids = false;
        BossWon = false;
        StopTimer = false;
        BossTime = false;
        isTimerDone = false;
        StartCoroutine(Timer());
    }
    private void Update() 
    {
        if(currentTime <= 0 
            && isTimerDone == false)
        {
            isTimerDone = true;
            BossTime = true;
            CountDown.text="BOSS TIME";
            StartCoroutine(BossTimeText());
            GameObject.FindObjectOfType<LifePointScript>().BossUI();
            GameObject.FindObjectOfType<BossSpawnerScript>().SpawnBoss();
        }
        if(BossWon == true)
        {
            StopShootingAndAsteroids = true;
            BossWon = false;
            CountDown.text="WINNER";
            StartCoroutine(BossDefeated());
        }
    }
    private IEnumerator Timer()
    {
        currentTime = startTime;
        do
        {
            currentTime -= Time.deltaTime;
            TimerCountDown();
            yield return null;
        }
        while(currentTime > 0 && StopTimer == false);
    }
    private void TimerCountDown()
    {
        int minutes = (int)(currentTime / 60) % 60;
        int seconds = (int)(currentTime % 60);

        CountDown.text="";
        if(minutes > 0 && minutes < 10 && seconds != 0) {CountDown.text += "0" + minutes + ":";}
        else if(minutes > 0 && minutes > 10 && seconds != 0){CountDown.text += minutes + ":";}
        else if(minutes > 0  && seconds <= 0){CountDown.text += "0" + minutes + ":00";}
       
       
        if(seconds > 0 && seconds > 10) {CountDown.text += seconds;}
        else if(seconds > 0 && seconds < 10 ) {CountDown.text += "0" + seconds;}
        else if(minutes <= 0 && seconds == 10){CountDown.text += "10";}
        else if(minutes == 1 && seconds == 10){CountDown.text = "0" + minutes + ":10";}
    }

    private IEnumerator BossTimeText()
    {
        while(BossTime == true)
        {   
            CountDown.color = new Color32(209, 203, 149, 255);
            yield return new WaitForSeconds(1f - TickFaster);
            CountDown.color = new Color32(64, 152, 94, 255);
            yield return new WaitForSeconds(1f - TickFaster);
        }
    }

    private IEnumerator BossDefeated()
    {
        while(BossWon == true)
        {
            CountDown.color = new Color32(209, 203, 149, 255);
            yield return new WaitForSeconds(2f);
            CountDown.color = new Color32(64, 152, 94, 255);
            yield return new WaitForSeconds(2f);
        }
    }
}
