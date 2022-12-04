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
        Debug.Log(index50000.activeSelf);
        Debug.Log(index250000.activeSelf);
        Debug.Log(index500000.activeSelf);
        Debug.Log(index1000000.activeSelf);
        Debug.Log(pm.mapData["share_image_path"].ToString());
        //공유용 이미지 존재 확인 및 인터넷 확인
        if (pm.mapData["share_image_path"].Length > 0 && !index50000.activeSelf && !index250000.activeSelf && !index500000.activeSelf && !index1000000.activeSelf && Application.internetReachability != NetworkReachability.NotReachable)
        {
            mainCam.transform.position = new Vector3(0, 0, 0);
            //pm.mapData["share_image_path"]의 파일 크기가 25Mb 이상이면...
            if (pm.mapData["share_image_path"].Length < 25000000)
            {
                naviCanvas = GameObject.Find("NaviCanvas");

                if (naviCanvas != null) {
                    naviCanvas.GetComponent<Canvas>().sortingOrder = 1;
                }

                GameObject newPref = Instantiate(sharePanel, canvas.transform);
                newPref.transform.SetAsLastSibling();
            }
        }


    }
}
