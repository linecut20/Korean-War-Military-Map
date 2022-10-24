using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneEventSystem : MonoBehaviour
{
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
        
    }
}
