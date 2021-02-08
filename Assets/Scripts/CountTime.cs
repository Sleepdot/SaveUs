using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
   public float startingTime;
   public Text countdownText;
   public float endTime, maxTime, minTime, TimeAdd, TimeSubtract;


   void start()
   {
       startingTime = 100;
       countdownText.text = startingTime.ToString();
       Time.timeScale = 0f;
   }

   void Update()
   {
    
        startingTime -= Time.deltaTime;
        countdownText.text = Mathf.Round(startingTime).ToString("0");

        
        if(startingTime <= 0)
        {
            startingTime = 0;
            Time.timeScale = 0f;
            FindObjectOfType<GameManage>().TimeOut();
        }
        
      
   }

   public void addTime()
   {
       startingTime += TimeAdd;
       countdownText.text = Mathf.Round(startingTime).ToString("0");
   }

   public void subtractTime()
   {
       startingTime -= TimeSubtract;
       countdownText.text = Mathf.Round(startingTime).ToString("0");
   }
}
