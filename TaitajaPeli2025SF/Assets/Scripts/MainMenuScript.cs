using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    void Start()
    {
        playButton.onClick.AddListener(LoadScene);
        quitButton.onClick.AddListener(closeGame);
    }

    void LoadScene()
    {
        Debug.Log("lol");
        SceneManager.LoadScene("SampleScene");
    }

    void closeGame()
    {
        Application.Quit();
    }
}
