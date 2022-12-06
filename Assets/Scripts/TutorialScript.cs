using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorialPanel;
    public Sprite[] tutorials;
    public GameObject btnBack;
    public GameObject btnNext;
    public ProjectManager pm;

    private int time = 4;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        pm.tutorialIndex = 0;

        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (pm.tutorialIndex == 0)
        {
            btnBack.SetActive(false);
        }
        else
        {
            btnBack.SetActive(true);
        }

        if (pm.tutorialIndex == 4)
        {
            btnNext.SetActive(false);
        }
        else
        {
            btnNext.SetActive(true);
        }
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            time--;
            if (time == 0)
            {
                if (pm.tutorialIndex == 4)
                {
                    pm.tutorialIndex = 0;
                }
                else
                {
                    pm.tutorialIndex++;
                }
                tutorialPanel.GetComponent<UnityEngine.UI.Image>().sprite = tutorials[pm.tutorialIndex];
                time = 4;
            }
        }
    }
}
