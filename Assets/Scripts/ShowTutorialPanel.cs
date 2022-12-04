using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorialPanel : MonoBehaviour
{
    public GameObject canvas;
    public GameObject tutorialPanel;
    public GameObject naviCanvas;
    public GameObject mainCam;
    public ProjectManager pm;
    
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        pm.tutorialIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowTutorialPanelFunc()
    {
        mainCam.transform.position = new Vector3(0, 0, 0);
        naviCanvas = GameObject.Find("NaviCanvas");
        if (naviCanvas != null) {
            naviCanvas.GetComponent<Canvas>().sortingOrder = 1;
        }
        

        GameObject newPref = Instantiate(tutorialPanel, canvas.transform);
        newPref.transform.SetAsLastSibling();
    }
}
