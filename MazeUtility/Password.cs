using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour
{
    public Text dialogText;
    public Text titleText;
    public GameObject dialog;
    public Door door;
    public Button continueButton;

    private string chars = "1234567890ABCabc";
    // Start is called before the first frame update
    void Start()
    {
        Teleport();
    }

    private void OnTriggerStay(Collider other) {
        OnTriggerEnter(other);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            var random = new System.Random();
            string randomPass = chars[random.Next(0,15)].ToString();
            randomPass += chars[random.Next(0,15)].ToString();
            randomPass += chars[random.Next(0,15)].ToString();
            randomPass += chars[random.Next(0,15)].ToString();
            randomPass += chars[random.Next(0,15)].ToString();

            dialogText.text = "\"Poor soul... In order to scape from here, remember this: " + randomPass + "\"";
            titleText.text = "You hear a voice...";

            dialog.SetActive(true);
            door.password = randomPass;
            continueButton.gameObject.SetActive(true);
            Destroy(this.gameObject);         
        }
        else
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        var random = new System.Random();
        this.transform.position = new Vector3(random.Next(1, 37), 1, random.Next(-9, 32));
    }
}
