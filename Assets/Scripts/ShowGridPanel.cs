using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGridPanel : MonoBehaviour
{
    public GameObject canvas;
    public GameObject gridPanel;
    public GameObject indexCanvas;
    public GameObject naviCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GridButtonTouchedFunc()
    {


        if (GameObject.Find("GridPanel(Clone)") == null)
        {
            indexCanvas = GameObject.Find("IndexCanvas");
            indexCanvas.GetComponent<Canvas>().sortingOrder = 1;

            naviCanvas = GameObject.Find("NaviCanvas");
            if (naviCanvas != null) {
                naviCanvas.GetComponent<Canvas>().sortingOrder = 1;
            }
            
            
            GameObject newPref = Instantiate(gridPanel, canvas.transform);
        }
        else
        {
            indexCanvas = GameObject.Find("IndexCanvas");
            indexCanvas.GetComponent<Canvas>().sortingOrder = 2;

            naviCanvas = GameObject.Find("NaviCanvas");

            if (naviCanvas != null) {
                naviCanvas.GetComponent<Canvas>().sortingOrder = 2;
            }
            

            Destroy(GameObject.Find("GridPanel(Clone)"));
        }
    }
}
