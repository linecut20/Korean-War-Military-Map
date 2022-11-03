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

    public void ScaleButtonTouchedFunc(int scale)
    {
        pm.scale = scale;
        ScaleButtonInit(scale);
    }

    private void ScaleButtonInit(int scale)
    {

        switch (scale)
        {
            case 0:
                ScaleButton1.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#B97C37", out Color color) ? color : Color.white;
                ScaleButton2.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color2) ? color2 : Color.white;
                ScaleButton3.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color3) ? color3 : Color.white;
                ScaleButton4.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color4) ? color4 : Color.white;
                break;
            case 1:
                ScaleButton1.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color5) ? color5 : Color.white;
                ScaleButton2.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#B97C37", out Color color6) ? color6 : Color.white;
                ScaleButton3.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color7) ? color7 : Color.white;
                ScaleButton4.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color8) ? color8 : Color.white;
                break;
            case 2:
                ScaleButton1.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color9) ? color9 : Color.white;
                ScaleButton2.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color10) ? color10 : Color.white;
                ScaleButton3.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#B97C37", out Color color11) ? color11 : Color.white;
                ScaleButton4.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color12) ? color12 : Color.white;
                break;

            case 3:
                ScaleButton1.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color13) ? color13 : Color.white;
                ScaleButton2.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color14) ? color14 : Color.white;
                ScaleButton3.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#493721", out Color color15) ? color15 : Color.white;
                ScaleButton4.GetComponent<Image>().color = ColorUtility.TryParseHtmlString("#B97C37", out Color color16) ? color16 : Color.white;
                break;
            default: break;
        }
    }
}
