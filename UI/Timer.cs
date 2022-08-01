using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timerRunning = false;

    public GameObject panel;    

    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerRunning)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                timeLeft = 0;
                timerRunning = false;
                ShowGameOverScreen();
            }
        }        
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime%60);

        timerText.text = minutes + ":";
        timerText.text += (seconds < 10 ? "0" + seconds.ToString() : seconds.ToString());
    }

    void ShowGameOverScreen()
    {
        panel.gameObject.SetActive(true);
    }
}
