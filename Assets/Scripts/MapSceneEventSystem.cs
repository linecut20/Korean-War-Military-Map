using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneEventSystem : MonoBehaviour
{
    public ProjectManager projectManager;
    public GameObject scaleBtn0;
    public GameObject scaleBtn1;
    public GameObject scaleBtn2;
    public GameObject scaleBtn3;
    public GameObject mapCamera;
    
    private int scale = 0;

    void Start()
    {
        projectManager = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        scaleBtn0 = GameObject.Find("ScaleBtn0");
        scaleBtn1 = GameObject.Find("ScaleBtn1");
        scaleBtn2 = GameObject.Find("ScaleBtn2");
        scaleBtn3 = GameObject.Find("ScaleBtn3");
        scale = projectManager.scale;

        switch (scale) {
            case 0: 
                scaleBtn0.GetComponent<UnityEngine.UI.Button>().Select();
                break;
            case 1:
                scaleBtn1.GetComponent<UnityEngine.UI.Button>().Select();
                break;
            case 2:
                scaleBtn2.GetComponent<UnityEngine.UI.Button>().Select();
                break;
            case 3:
                scaleBtn3.GetComponent<UnityEngine.UI.Button>().Select();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
