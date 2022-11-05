using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchScript : MonoBehaviour
{
    public ProjectManager pm;
    public GameObject searchInput;
    public GameObject searchText;
    public GameObject confirmButton;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputTouch()
    {
        if (System.Diagnostics.Process.GetProcessesByName("OSK").Length > 0)
        {
            System.Diagnostics.Process.GetProcessesByName("OSK")[0].MainWindowHandle.ToInt32();
        }
        else
        {
            System.Diagnostics.Process.Start("OSK.exe");
        }
    }

    public void SearchKeywordConfirm() {
        string keyword = searchInput.GetComponent<TMP_InputField>().text;
        searchInput.GetComponent<TMP_InputField>().text = "";

        
        
    }
}
