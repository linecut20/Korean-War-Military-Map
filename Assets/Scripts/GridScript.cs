using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GridScript : MonoBehaviour
{
    public GameObject sheet;
    public GameObject plane;
    public ProjectManager pm;
    private MapSceneEventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GridItemTouchedFunc()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>();

        string sheetString = sheet.GetComponent<TextMeshProUGUI>().text;

        int mapIndex = eventSystem.mapData.FindIndex(x => x["sheet"] == sheetString);
        eventSystem.OnItemTouched(mapIndex);

        GameObject panel;

        switch (pm.scale) {
            case 0:
                panel = GameObject.Find("GridPanel50000(Clone)");
                DestroyImmediate(panel, true);
                break;

            case 1:
                panel = GameObject.Find("GridPanel250000(Clone)");
                DestroyImmediate(panel, true);
                break;

            case 2:
                panel = GameObject.Find("GridPanel500000(Clone)");
                DestroyImmediate(panel, true);
                break;

            case 3:
                panel = GameObject.Find("GridPanel1000000(Clone)");
                DestroyImmediate(panel, true);
                break;
        }
    }
}
