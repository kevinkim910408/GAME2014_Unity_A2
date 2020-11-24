using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: InstructorButtons.cs
/// Date last Modified: 2020-11-24
/// Program description
///  - Managing back button to go to the main menu, and set active or deactive the panels 
///  
/// Revision History
/// 2020-11-18: Added functions to all buttons  
/// 2020-11-24: Added one more page to the instructor
/// 
/// </summary>

public class InstructorButtons : MonoBehaviour
{
    // scene name
    [Header("Scene Names")]
    public string backScene;

    [Header("Panels")]
    // panels
    public GameObject panelOne;
    public GameObject panelTwo;
    public GameObject panelThree;

    [Header("Buttons")]
    // buttons
    public GameObject previousButton;
    public GameObject nextButton;

    private int buttonCount = 0;

    private void Start()
    {
        // at first, cannot see the second panel and the previous button
        panelOne.SetActive(true);
        panelTwo.SetActive(false);
        panelThree.SetActive(false);

        previousButton.SetActive(false);
        nextButton.SetActive(true);
    }


    public void onBack()
    {
        SceneManager.LoadScene(backScene);
    }
    public void onPrevious()
    {
        buttonCount--;
        if (buttonCount % 3 == 0)
        {
            panelOne.SetActive(true);
            panelTwo.SetActive(false);
            panelThree.SetActive(false);

            previousButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if (buttonCount % 3 == 2)
        {
            panelOne.SetActive(false);
            panelTwo.SetActive(true);
            panelThree.SetActive(false);

            previousButton.SetActive(true);
            nextButton.SetActive(false);
        }
        else if (buttonCount % 3 == 1)
        {
            panelOne.SetActive(false);
            panelTwo.SetActive(true);
            panelThree.SetActive(false);

            previousButton.SetActive(true);
            nextButton.SetActive(true);
        }
    }
    public void onNext()
    {

        buttonCount++;
        if (buttonCount % 3 == 0) // first page
        {
            panelOne.SetActive(true);
            panelTwo.SetActive(false);
            panelThree.SetActive(false);

            previousButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if(buttonCount % 3 == 2) // thrid page
        {
            panelOne.SetActive(false);
            panelTwo.SetActive(false);
            panelThree.SetActive(true);

            previousButton.SetActive(true);
            nextButton.SetActive(false);
        }
        else if (buttonCount % 3 == 1) // second page
        {
            panelOne.SetActive(false);
            panelTwo.SetActive(true);
            panelThree.SetActive(false);

            previousButton.SetActive(true);
            nextButton.SetActive(true);
        }
    }

}
