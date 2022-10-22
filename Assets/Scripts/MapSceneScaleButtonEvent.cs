using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneScaleButtonEvent : MonoBehaviour
{
    public GameObject ScaleBtn0;
    public GameObject ScaleBtn1;
    public GameObject ScaleBtn2;
    public GameObject ScaleBtn3;
    public ProjectManager pm;
    
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();

        ScaleBtn0 = GameObject.Find("ScaleBtn0");
        ScaleBtn1 = GameObject.Find("ScaleBtn1");
        ScaleBtn2 = GameObject.Find("ScaleBtn2");
        ScaleBtn3 = GameObject.Find("ScaleBtn3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScaleBtn0Clicked(int value) {
        pm.scale = value;
    }
}
