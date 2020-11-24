using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: BlockStatus.cs
/// Date last Modified: 2020-11-24
/// Program description
///  - Contain the basic stats of blocks
///  
/// Revision History
/// 2020-11-17: Added some variables what i need 
/// 2020-11-24: Position reset function if block hits death plane. 
/// 
/// </summary>

public class BlockStatus : MonoBehaviour
{
    public string type;
    public float value = 0;
    public GameObject portal;

    public GameObject newPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "DeathPlane")
        {
            transform.position = newPosition.transform.position;
        }
    }
}
