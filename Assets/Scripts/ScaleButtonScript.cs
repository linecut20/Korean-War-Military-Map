using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScaleButtonScript : MonoBehaviour
{
    public ProjectManager pm;
    public GameObject ScaleButton1;
    public GameObject ScaleButton2;
    public GameObject ScaleButton3;
    public GameObject ScaleButton4;


    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();

        ScaleButtonInit(pm.scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleButtonTouchedFunc(int scale) {
        pm.scale = scale;
        ScaleButtonInit(scale);
    }

    private void ScaleButtonInit(int scale) {
       
    }
}
