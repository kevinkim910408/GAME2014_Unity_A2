using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: PauseButton.cs
/// Date last Modified: 2020-11-25
/// Program description
///  - Managing after pressing the pause button
///  
/// Revision History
/// 2020-11-25:  Added the functions for pausing the game
/// </summary>
/// 
public class PauseButton : MonoBehaviour
{
    [Header("Scene Name")]
    public string MenuScene;

    [Header("Panels")]
    public GameObject pausePanel;



    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }


    public void onResume()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }

    public void onMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(MenuScene);
    }

    public void onPause()
    {
        Time.timeScale = 0.0f;
        pausePanel.SetActive(true);
    }
}
