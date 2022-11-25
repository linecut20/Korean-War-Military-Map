using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGridPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject btn;
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

    public void CloseButtonTouchedFunc()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();

        switch (pm.scale) {
            case 0:
                DestroyImmediate(GameObject.Find("GridPanel50000(Clone)"), true);
                break;

            case 1:
                DestroyImmediate(GameObject.Find("GridPanel250000(Clone)"), true);
                break;

            case 2:
                DestroyImmediate(GameObject.Find("GridPanel500000(Clone)"), true);
                break;  

            case 3:
                DestroyImmediate(GameObject.Find("GridPanel1000000(Clone)"), true);
                break;
        }

        eventSystem = GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>();
        eventSystem.ChangePlaneMaterial(0);
    }
}
