using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: DieButton.cs
/// Date last Modified: 2020-11-24
/// Program description
///  - Managing after dead
///  
/// Revision History
/// 2020-11-18:  Added the function of set active / deactive die panel
///              This function will be unabled.
/// 2020-11-24:  Die button function is deleted
/// </summary>
/// 
public class DieButton : MonoBehaviour
{
    [Header("Scene Name")]
    public string MenuScene;
    public string StartScene;

    [Header("Panels")]
    public GameObject diePanel;



    // Start is called before the first frame update
    void Start()
    {
        diePanel.SetActive(false);
    }


    public void onRetry()
    {
        Time.timeScale = 1.0f;
        diePanel.SetActive(false);

        // make score = 0, so player should start from 0
        ScoreManager.ScoreZero();
        SceneManager.LoadScene(StartScene);
    }

    public void onMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(MenuScene);
    }

}
