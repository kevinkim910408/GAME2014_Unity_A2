using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: NextStage.cs
/// Date last Modified: 2020-11-24
/// Program description
///  - If player hit the goal point, this script will help player to move to next stage(open a panel)
///  
/// Revision History
/// 2020-11-24: Added on trigger enter 2d method
/// 
/// </summary>

public class NextStage : MonoBehaviour
{
    public GameObject winPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0.0f;
            winPanel.SetActive(true);
        }
    }
}
