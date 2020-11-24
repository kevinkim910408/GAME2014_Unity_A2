using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: NextStageButton.cs
/// Date last Modified: 2020-11-24
/// Program description
///  - Managing after clear the stage
///  
/// Revision History
/// 2020-11-24:  Added functions for two buttons ( back to menu, go to next stage)
/// </summary>
/// 
public class NextStageButton : MonoBehaviour
{
    [Header("Scene Name")]
    public string MenuScene;
    public string NextScene;

    [Header("Panels")]
    public GameObject winPanel;



    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
    }


    public void onNext()
    {
        Time.timeScale = 1.0f;
        winPanel.SetActive(false);

        SceneManager.LoadScene(NextScene);
    }

    public void onMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(MenuScene);
    }

}
