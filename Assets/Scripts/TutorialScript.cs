using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorialPanel;
    public Sprite[] tutorials;
    public GameObject btnBack;
    public GameObject btnNext;
    public GameObject btnClose;
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
        if (pm.tutorialIndex == 0) {
            
            btnBack.SetActive(false);
        } else {
            btnBack.SetActive(true);
        }

        if (pm.tutorialIndex == 4) {
            btnNext.SetActive(false);
        } else {
            btnNext.SetActive(true);
        }
    }

    public void BtnCloseFunc()
    {
        Destroy(tutorialPanel);
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
