using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNoMapPanel : MonoBehaviour
{

    public GameObject noMapPanel;
    public GameObject indexCanvas;
    public GameObject naviCanvas;
    public GameObject btn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyNoMapPanelFunc()
    {
        indexCanvas = GameObject.Find("IndexCanvas");
        indexCanvas.GetComponent<Canvas>().sortingOrder = 2;

        naviCanvas = GameObject.Find("NaviCanvas");

        if (naviCanvas != null) {
            naviCanvas.GetComponent<Canvas>().sortingOrder = 2;
        }
        
        Destroy(noMapPanel);
    }
}
