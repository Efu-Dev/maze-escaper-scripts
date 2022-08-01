using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject dialog;
    public Text titleText;
    public Text contentText;
    public GameObject textInput;
    public Button entryButton;
    public string password;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            titleText.text = "You hear a voice from the other side...";
            contentText.text = "\"Only those souls who know the secret can leave.\"";
            dialog.SetActive(true);
            textInput.SetActive(true);
            entryButton.gameObject.SetActive(true);
        }
    }
}
