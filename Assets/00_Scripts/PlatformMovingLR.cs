using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Name: Junho Kim
/// Student#: 101136986
/// The Source file name: PlatformMovingLR.cs
/// Date last Modified: 2020-11-24
/// Program description
///  - platforms move left to right and right to left
///  
/// Revision History
/// 2020-11-24: Added functions of moving
/// 
/// </summary>

public class PlatformMovingLR : MonoBehaviour
{
    public float xPosition01;
    public float xPosition02;
    public float moveSpeed;
    bool moveLeft;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xPosition01)
            moveLeft = false;
        if (transform.position.x > xPosition02)
            moveLeft = true;

        if (moveLeft)
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
    }

}
