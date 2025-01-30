using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreenScript : MonoBehaviour
{
    public Button menuButton;
    // Start is called before the first frame update
    void Start()
    {
        menuButton.onClick.AddListener(LoadMenu);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
