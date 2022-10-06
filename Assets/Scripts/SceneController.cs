using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            moveToMap();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            moveToFirst();
        }
    }

    private void moveToFirst()
    {
        SceneManager.LoadScene(0);
    }

    private void moveToMap()
    {
        SceneManager.LoadScene(1);
    }
}
