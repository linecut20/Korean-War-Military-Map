using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexMapButtonScript : MonoBehaviour
{
    public int scale;
    public string sheet;
    public GameObject indexImage50000;
    public GameObject indexImage250000;
    public GameObject indexImage500000;
    public GameObject IndexImage1000000;
    public GameObject indexButton;
    public GameObject textNoMap;
    public GameObject imageArea;
    public GameObject topButton;
    public GameObject naviCanvas;
    public ProjectManager pm;

    private MapSceneEventSystem eventSystem;
    private int mapIndex;


    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();

            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                if (hitInfo.transform.gameObject == indexButton)
                {
                    OnIndexButtonFunc();
                }
            }
        }
    }

    public void OnIndexButtonFunc()
    {
        if (!pm.touched)
        {
            pm.touched = true;

            if (sheet != "none")
            {
                mapIndex = eventSystem.mapData.FindIndex(x => x["sheet"] == sheet);
                eventSystem.OnItemTouched(mapIndex);
            }
            else
            {
                switch (scale)
                {
                    case 50000:
                        eventSystem.mapData = pm.mapDataScale1;
                        indexImage50000.SetActive(false);
                        break;

                    case 250000:
                        eventSystem.mapData = pm.mapDataScale2;
                        indexImage250000.SetActive(false);
                        break;

                    case 500000:
                        eventSystem.mapData = pm.mapDataScale3;
                        indexImage500000.SetActive(false);
                        break;

                    case 1000000:
                        eventSystem.mapData = pm.mapDataScale4;
                        IndexImage1000000.SetActive(false);
                        break;
                }

                //sheet 자체가 없는 경우
                naviCanvas = GameObject.Find("NaviCanvas");
                textNoMap.SetActive(true);
                imageArea.SetActive(false);
                topButton.SetActive(true);

                if (naviCanvas != null)
                {
                    naviCanvas.GetComponent<Canvas>().sortingOrder = 1;
                }
            }
            pm.touched = false;
        }
    }
}
