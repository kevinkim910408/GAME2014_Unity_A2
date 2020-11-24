using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: PlatformMovingUD.cs
/// Date last Modified: 2020-11-24
/// Program description
///  - platforms move up do down and down to up
///  
/// Revision History
/// 2020-11-24: Added functions of moving
/// 
/// </summary>

public class PlatformMovingUD : MonoBehaviour
{
    public float yPosition01;
    public float yPosition02;
    public float moveSpeed;
    bool moveDown;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > yPosition01)
            moveDown = true;
        if (transform.position.y < yPosition02)
            moveDown = false;

        if (moveDown)
            transform.position = new Vector2(transform.position.x , transform.position.y - moveSpeed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x , transform.position.y + moveSpeed * Time.deltaTime);
    }

}
