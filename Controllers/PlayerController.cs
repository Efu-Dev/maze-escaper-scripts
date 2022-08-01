using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12.0f;
    public bool canMove = true;
    public GameObject pause;
    public Timer timer;

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);
        }       
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(pause.activeSelf)
            {
                canMove = true;
                timer.timerRunning = true;
                pause.SetActive(false);
            }
            else
            {
                canMove = false;
                timer.timerRunning = false;
                pause.SetActive(true);
            }     
        }
    }
}
