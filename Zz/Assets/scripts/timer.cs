using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.EventSystems;
public class timer : MonoBehaviour

{
    public Text timers;
    [SerializeField]
    public Text day;
    [SerializeField]
    public GameObject firstprompt;
    [SerializeField]
    public GameObject Secondprompt;
    [SerializeField]
    public GameObject clock1;
    [SerializeField]
    public GameObject clock2;
    [SerializeField]
    public GameObject clock3;
    [SerializeField]
    public GameObject clock4;
    [SerializeField]
    public GameObject clock5;
    [SerializeField]

    float totalTime = 0f;
    int change=0;
    public int time = 0;
    int time2=0;
    public int timerec = 0;
    Boolean switchs = false;
    int minutes = 0;

    int counter = 0;

    // Start is called before the first frame update
    void UpdateLevelTimer(float totalSeconds)
    {
        
            int sysHour = System.DateTime.Now.Hour;


        int minutes = sysHour;
        
        
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);
               
          string formatedSeconds = seconds.ToString();

        

        if (seconds == 60)
                {
                    seconds = 0;
                     minutes += 1;

          

        }
       
       

       

        // change = 0;
        //   Time.timeScale = 0.5f;

        timers.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            time = seconds;
            time2 = minutes;
        if (time == 5 && time2 == sysHour)
        {
            firstprompt.SetActive(true);
        }
        if (time==timerec+12.0f && switchs != false)
        {
            Secondprompt.SetActive(true);
        }

        if (time == 0)
        {
            clock1.SetActive(true);
            clock5.SetActive(false);
        }
        if (time == 10)
        {
            clock2.SetActive(true);
            clock1.SetActive(false);
        }
        if (time == 20)
        {
            clock3.SetActive(true);
            clock2.SetActive(false);
        }
        if (time == 40) {
            clock4.SetActive(true);
            clock3.SetActive(false);
        }
        if (time == 50) {
            clock5.SetActive(true);
            clock4.SetActive(false);
        }

    }


    public void MyOnClickFunction(string MyString)
    {
        Debug.Log(MyString);
    }
    void Start()
    {
        totalTime = 0f;

       
        //if (sysHour >= 13)
        {

           // firstprompt.SetActive(true);

            // if (MyOnClickFunction "Btn1"))//this is Btn1
            //{





        }

    }
     void Update()
    {


        //  Time=Time.
        //   StartCoroutine(Waits());

        int sysHour = System.DateTime.Now.Hour;
       
           totalTime += Time.deltaTime*2;
        UpdateLevelTimer(totalTime);
        // Debug.Log(totalTime);
        timerecorderp2();



    }
    IEnumerator Waits()
    {
        yield return new WaitForSeconds(200f);

    }
    public int Returnertime()
    {
        return time;
    }
   public int Returnertime2()
    {
        return time2;
    }



    public void switchprompt2()
    {
       switchs=true;
    }
    public void timerecorderp2()

    {
        if (switchs == true)
        {
            int timerec = time;
        }
    }
}
