using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSharePanel : MonoBehaviour
{
    public GameObject sharePanel;
    public GameObject shareButton;
    public GameObject canvas;
    public GameObject mainCam;
    public GameObject naviCanvas;
    public GameObject index50000;
    public GameObject index250000;
    public GameObject index500000;
    public GameObject index1000000;
    public ProjectManager pm;

    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShareButtonTouchedFunc()
    {
        //인터넷 확인
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            mainCam.transform.position = new Vector3(0, 0, 0);


            naviCanvas = GameObject.Find("NaviCanvas");

            if (naviCanvas != null)
            {
                naviCanvas.GetComponent<Canvas>().sortingOrder = 1;
            }

            GameObject newPref = Instantiate(sharePanel, canvas.transform);
            newPref.transform.SetAsLastSibling();
        }


    }
}
