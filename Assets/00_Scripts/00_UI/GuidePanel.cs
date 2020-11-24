using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePanel : MonoBehaviour
{
    public GameObject guidePanel;


    // Start is called before the first frame update
    void Start()
    {
        guidePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0.0f;
            guidePanel.SetActive(true);
        }
    }

    public void OnReady()
    {
        Time.timeScale = 1.0f;
        guidePanel.SetActive(false);
        Destroy(gameObject);
    }
}
