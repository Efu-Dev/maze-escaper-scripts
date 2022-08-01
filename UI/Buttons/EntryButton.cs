using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryButton : MonoBehaviour
{
    public GameObject dialog;
    public Timer timer;
    public Door door;
    public Text enteredPass;
    public GameObject input;
    public Text content;
    public Button continueButton;
    public Button victory;
    public PlayerController controller;

    private void Awake() {
        this.gameObject.GetComponent<Button>().onClick.AddListener(CheckVictory);
    }

    private void OnEnable() {
        timer.timerRunning = false;
        controller.canMove = false; 
    }

    private void Dispose()
    {
        timer.timerRunning = true;
        controller.canMove = true;
        dialog.SetActive(false);
    }

    private void CheckVictory() {
        input.SetActive(false);
        if(door.password.Equals("") || !enteredPass.text.Equals(door.password))
        {
            content.text = "\"That is not correct, damned soul... Go back to your confinement.\"";
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            float minutes = Mathf.FloorToInt(timer.timeLeft/60);
            float seconds = Mathf.FloorToInt(timer.timeLeft%60);
            content.text = "\"You may leave this jail, soul...\"\n- Time remaining: " + minutes + ":" + seconds;
            victory.gameObject.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
