using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchClear : MonoBehaviour
{
    public GameObject searchClearBtn;
    public ProjectManager pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SearchClearBtnFunc()
    {
        switch (pm.scale)
        {
            case 0:
                GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>().mapData = pm.mapDataScale1;
                break;
            case 1:
                GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>().mapData = pm.mapDataScale2;
                break;
            case 2:
                GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>().mapData = pm.mapDataScale3;
                break;
            case 3:
                GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>().mapData = pm.mapDataScale4;
                break;
            default:
                break;
        }
        Destroy(searchClearBtn);
        GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>().MapDataItemInit();
    }
}
