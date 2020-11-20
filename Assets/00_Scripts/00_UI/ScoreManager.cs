using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: ScoreManager.cs
/// Date last Modified: 2020-11-20
/// Program description
///  - Manage scores with static, so i can call this script from anywhere.
///  
/// Revision History
/// 2020-11-20:  Added static variable and get, set functions
/// 
/// </summary>
/// 

public class ScoreManager : MonoBehaviour
{
    // static variable, so can call this from anywhere
    static int score = 0;

    // get
    public static void SetScore(int _score)
    {
        score += _score;
    }

    // set
    public static int GetScore()
    {
        return score;
    }
}
