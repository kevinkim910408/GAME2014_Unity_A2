using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: JoyButtonManager.cs
/// Date last Modified: 2020-11-25
/// Program description
///  - help joy buttons controls
///  
/// Revision History
/// 2020-11-25:  Added the functions for controlling joy buttons - left, right and jump
/// </summary>
/// 

public class JoyButtonManager : MonoBehaviour
{
    // components
    GameObject player;
    PlayerMovement playerMovement;

    // init
    public void InitComponents()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }


    // event trigger point down 
    public void LeftClickDown()
    {
        Debug.Log("left d");
        playerMovement.inputLeft = true;
    }

    public void RightClickDown()
    {
        Debug.Log("right d");
        playerMovement.inputRight = true;
    }
    public void JumpClickDown()
    {
        Debug.Log("jump d");
        playerMovement.inputJump = true;
    }



    // event trigger point up
    public void LeftClickUp()
    {
        Debug.Log("left u");
        playerMovement.inputLeft = false;
    }

    public void RightClickUp()
    {
        Debug.Log("right u");
        playerMovement.inputRight = false;
    }
    public void JumpClickUp()
    {
        Debug.Log("jump u");
        playerMovement.inputJump = false;
    }
}
