using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: TitleButtons.cs
/// Date last Modified: 2020-11-18
/// Program description
///  - Managing start and instructor buttons 
///  
/// Revision History
/// 2020-11-18: Added functions to start and instructor buttons  
/// 
/// </summary>

public class TitleButtons : MonoBehaviour
{
    // scene name
    [Header("Scene Names")]
    public string startScene;
    public string InstructorScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStart()
    {
        SceneManager.LoadScene(startScene);
    }
    public void onInstructor()
    {
        SceneManager.LoadScene(InstructorScene);
    }
}
