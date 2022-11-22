using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonScript : MonoBehaviour
{
    public GameObject tutorialPanel;
    public Sprite[] tutorials;
    public GameObject btnBack;
    public GameObject btnNext;
    public ProjectManager pm;


    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        pm.tutorialIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnBackFunc()
    {
        if (pm.tutorialIndex > 0) {
            pm.tutorialIndex--;
        }
        
        tutorialPanel.GetComponent<UnityEngine.UI.Image>().sprite = tutorials[pm.tutorialIndex];
    }

    public void BtnNextFunc()
    {
        if (pm.tutorialIndex < 4) {
            pm.tutorialIndex++;
        }
        
        tutorialPanel.GetComponent<UnityEngine.UI.Image>().sprite = tutorials[pm.tutorialIndex];
    }
}
