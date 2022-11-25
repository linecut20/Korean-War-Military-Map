using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSharePanel : MonoBehaviour
{
    public GameObject sharePanel;
    public GameObject shareButton;
    public GameObject canvas;
    public GameObject naviCanvas;
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
        //공유용 이미지 존재 확인 및 인터넷 확인
        if (pm.mapData["share_image_path"] != null && Application.internetReachability != NetworkReachability.NotReachable)
        {
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
