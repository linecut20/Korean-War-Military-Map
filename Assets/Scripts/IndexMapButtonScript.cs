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
    public GameObject canvas;
    public GameObject noMapPanel;
    public GameObject imageArea;
    public GameObject topButton;
    public GameObject naviCanvas;
    public GameObject sharePanel;
    public ProjectManager pm;

    private MapSceneEventSystem eventSystem;
    private int mapIndex;

    private GameObject preSelected = null;
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
                    preSelected = hitInfo.transform.gameObject;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hitInfo = new RaycastHit();

            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (hitInfo.transform.gameObject == indexButton && preSelected == indexButton)
                {
                    OnIndexButtonFunc();
                }
            }
        }        
    }

    public void OnIndexButtonFunc()
    {
        GameObject noPanelPref = GameObject.Find("NoMapPanel(Clone)");
        GameObject grid50000Pref = GameObject.Find("GridPanel50000(Clone)");
        GameObject grid250000Pref = GameObject.Find("GridPanel250000(Clone)");
        GameObject grid500000Pref = GameObject.Find("GridPanel500000(Clone)");
        GameObject grid1000000Pref = GameObject.Find("GridPanel1000000(Clone)");
        sharePanel = GameObject.Find("Share Panel(Clone)");

        
        if (sharePanel == null && noPanelPref == null && grid50000Pref == null && grid250000Pref == null && grid500000Pref == null && grid1000000Pref == null)
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
                    //sheet 자체가 없는 경우
                    naviCanvas = GameObject.Find("NaviCanvas");

                    GameObject newp = Instantiate(noMapPanel, canvas.transform);

                    if (naviCanvas != null)
                    {
                        naviCanvas.GetComponent<Canvas>().sortingOrder = 1;
                    }
                }

                pm.touched = false;
            }
        }
    }
}
