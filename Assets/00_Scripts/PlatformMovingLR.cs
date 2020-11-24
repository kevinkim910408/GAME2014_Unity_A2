using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
