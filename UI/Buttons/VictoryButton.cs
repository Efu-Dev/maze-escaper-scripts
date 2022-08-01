using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryButton : MonoBehaviour
{
    private void Awake() {
        this.gameObject.GetComponent<Button>().onClick.AddListener(NextLevel);
    }

    private void NextLevel() {
        SceneManager.LoadScene("LevelTemplate");
    }
}
