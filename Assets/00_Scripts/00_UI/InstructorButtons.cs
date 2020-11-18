using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: InstructorButtons.cs
/// Date last Modified: 2020-11-18
/// Program description
///  - Managing back button to go to the main menu, and set active or deactive the panels 
///  
/// Revision History
/// 2020-11-18: Added functions to all buttons  
/// 
/// </summary>

public class InstructorButtons : MonoBehaviour
{
    // scene name
    [Header("Scene Names")]
    public string backScene;

    // panels
    public GameObject panelOne;
    public GameObject panelTwo;

    public GameObject previousButton;
    public GameObject nextButton;

    private void Start()
    {
        // at first, cannot see the second panel and the previous button
        panelOne.SetActive(true);
        panelTwo.SetActive(false);

        previousButton.SetActive(false);
        nextButton.SetActive(true);
    }


    public void onBack()
    {
        SceneManager.LoadScene(backScene);
    }
    public void onPrevious()
    {
        panelOne.SetActive(true);
        panelTwo.SetActive(false);

        previousButton.SetActive(false);
        nextButton.SetActive(true);
    }
    public void onNext()
    {
        panelOne.SetActive(false);
        panelTwo.SetActive(true);

        previousButton.SetActive(true);
        nextButton.SetActive(false);
    }
}
