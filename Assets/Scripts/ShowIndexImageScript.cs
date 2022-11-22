using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIndexImageScript : MonoBehaviour
{
    public GameObject imageArea;
    public GameObject indexImage50000;
    public GameObject indexImage250000;
    public GameObject indexImage500000;
    public GameObject IndexImage1000000;
    public GameObject naviCanvas;
    public GameObject textNoMap;
    public GameObject topButton;
    public ProjectManager pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        indexImage50000.SetActive(false);
        indexImage250000.SetActive(false);
        indexImage500000.SetActive(false);
        IndexImage1000000.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowIndexImageFunc()
    {
        imageArea.SetActive(false);
        topButton.SetActive(false);
        textNoMap.SetActive(false);

        naviCanvas = GameObject.Find("NaviCanvas");
        if (naviCanvas != null) {
            naviCanvas.GetComponent<Canvas>().sortingOrder = 2;
        }

        switch (pm.scale)
        {
            case 0:
                indexImage50000.SetActive(true);
                indexImage250000.SetActive(false);
                indexImage500000.SetActive(false);
                IndexImage1000000.SetActive(false);
                break;

            case 1:
                indexImage50000.SetActive(false);
                indexImage250000.SetActive(true);
                indexImage500000.SetActive(false);
                IndexImage1000000.SetActive(false);
                break;

            case 2:
                indexImage50000.SetActive(false);
                indexImage250000.SetActive(false);
                indexImage500000.SetActive(true);
                IndexImage1000000.SetActive(false);
                break;

            case 3:
                indexImage50000.SetActive(false);
                indexImage250000.SetActive(false);
                indexImage500000.SetActive(false);
                IndexImage1000000.SetActive(true);
                break;
        }

    }
}
