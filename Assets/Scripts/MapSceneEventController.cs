using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneEventController : MonoBehaviour
{
    public GameObject scaleBtn0;
    public GameObject scaleBtn1;
    public GameObject scaleBtn2;
    public GameObject scaleBtn3;
    public GameObject mapCamera;
    public ProjectManager projectManager;
    private int scale = 0;

    void Start()
    {
        projectManager = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        scale = projectManager.scale;
    }

    // Update is called once per frame
    void Update()
    {
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
}
