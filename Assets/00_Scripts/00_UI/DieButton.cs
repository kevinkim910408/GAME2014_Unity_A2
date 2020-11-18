using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: DieButton.cs
/// Date last Modified: 2020-11-18
/// Program description
///  - Managing after dead
///  
/// Revision History
/// 2020-11-18:  
/// 
/// </summary>
/// 
public class DieButton : MonoBehaviour
{
    [Header("Scene Name")]
    public string MenuScene;

    [Header("Panels")]
    public GameObject diePanel;

    // Start is called before the first frame update
    void Start()
    {
        diePanel.SetActive(false);
    }

    public void onDie()
    {
        Time.timeScale = 0.0f;
        diePanel.SetActive(true);
    }

    public void onResume()
    {
        Time.timeScale = 1.0f;
        diePanel.SetActive(false);
    }

    public void onMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(MenuScene);
    }

}
