using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(Quit);
    }

    void Quit() {
        Application.Quit();
    }
}
