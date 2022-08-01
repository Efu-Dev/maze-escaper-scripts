using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour{
    public GameObject dialog;
    public Timer timer;
    public PlayerController controller;

    private void Awake() {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Dispose);
    }

    private void OnEnable() {
        timer.timerRunning = false;
        controller.canMove = false; 
    }

    private void Dispose()
    {
        timer.timerRunning = true;
        controller.canMove = true;
        this.gameObject.SetActive(false);
        dialog.SetActive(false);
    }    
}
