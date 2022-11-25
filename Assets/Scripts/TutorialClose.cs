using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialClose : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject btnClose;
    public GameObject naviCanvas;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
          }

    public void BtnCloseFunc()
    {
        naviCanvas = GameObject.Find("NaviCanvas");
        if (naviCanvas != null) {
            naviCanvas.GetComponent<Canvas>().sortingOrder = 2;
        }

        Destroy(tutorialPanel);
    }
}
