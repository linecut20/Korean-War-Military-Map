using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScaleButtonScript : MonoBehaviour
{
    public ProjectManager pm;
    public GameObject ScaleButton1;
    public GameObject ScaleButton2;
    public GameObject ScaleButton3;
    public GameObject ScaleButton4;
    public GameObject imageArea;
    public GameObject topButton;
    
    public MapSceneEventSystem eventSystem;

    private GameObject gridPref;


    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>();

        ScaleButtonInit(pm.scale);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScaleButtonTouchedFunc(int scale)
    {
        if (pm.scale != scale)
        {
            //scale 바뀌기 전 전체보기 있는지 확인 후 삭제
            switch (pm.scale) {
                case 0:
                gridPref = GameObject.Find("GridPanel50000(Clone)");

                if (gridPref != null) {
                    DestroyImmediate(gridPref, true);
                }
                break;

                case 1:
                gridPref = GameObject.Find("GridPanel250000(Clone)");

                if (gridPref != null) {
                    DestroyImmediate(gridPref, true);
                }
                break;

                case 2:
                gridPref = GameObject.Find("GridPanel500000(Clone)");

                if (gridPref != null) {
                    DestroyImmediate(gridPref, true);
                }
                break;

                case 3:
                gridPref = GameObject.Find("GridPanel1000000(Clone)");

                if (gridPref != null) {
                    DestroyImmediate(gridPref, true);
                }
                break;
            }

            pm.scale = scale;
            ScaleButtonInit(scale);

            eventSystem.ChangePlaneMaterial(0);
        }
        
    }

    public void ScaleButtonInit(int scale)
    {
        switch (scale)
        {
            case 0:
                //ScaleButton1의 색상을 r = 185, g = 124, b = 55로 변경
                ScaleButton1.GetComponent<Image>().color = new Color(185f / 255f, 124f / 255f, 55f / 255f);
                ScaleButton2.GetComponent<Image>().color = new Color(32f, 70f, 73f);
                ScaleButton3.GetComponent<Image>().color = new Color(32f, 70f, 73f);
                ScaleButton4.GetComponent<Image>().color = new Color(32f, 70f, 73f);

                break;
            case 1:
                ScaleButton1.GetComponent<Image>().color = new Color(32f, 70f, 73f);
                ScaleButton2.GetComponent<Image>().color = new Color(185f / 255f, 124f / 255f, 55f / 255f);
                ScaleButton3.GetComponent<Image>().color = new Color(32f, 70f, 73f);
                ScaleButton4.GetComponent<Image>().color = new Color(32f, 70f, 73f);

                break;
            case 2:
                ScaleButton1.GetComponent<Image>().color = new Color(32f, 70f, 73f);
                ScaleButton2.GetComponent<Image>().color = new Color(32f, 70f, 73f);
                ScaleButton3.GetComponent<Image>().color = new Color(185f / 255f, 124f / 255f, 55f / 255f);
                ScaleButton4.GetComponent<Image>().color = new Color(32f, 70f, 73f);

                break;
            case 3:
                ScaleButton1.GetComponent<Image>().color = new Color(32f, 70f, 73f);
                ScaleButton2.GetComponent<Image>().color = new Color(32f, 70f, 73f);
                ScaleButton3.GetComponent<Image>().color = new Color(32f, 70f, 73f);
                ScaleButton4.GetComponent<Image>().color = new Color(185f / 255f, 124f / 255f, 55f / 255f);

                break;
            default: break;
        }

        imageArea.SetActive(false);
        topButton.SetActive(false);
        eventSystem.GetComponent<MapSceneEventSystem>().GetMapDataList(pm.scale);
        eventSystem.GetComponent<MapSceneEventSystem>().MapDataItemInit();
        eventSystem.GetComponent<MapSceneEventSystem>().IndexImageInit();
    }


}
