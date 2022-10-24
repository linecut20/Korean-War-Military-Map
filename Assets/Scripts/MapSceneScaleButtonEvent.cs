using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneScaleButtonEvent : MonoBehaviour
{
    public ProjectManager pm;
    
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScaleBtnClicked(int value) {
        pm.scale = value;
    }
}
