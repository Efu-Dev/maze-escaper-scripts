using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    private void Awake() {
        this.gameObject.GetComponent<Button>().onClick.AddListener(GameOver);
    }

    private void GameOver() {
        SceneManager.LoadScene("MainMenu");
    }
}
