using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Runtime.InteropServices;

public class SearchScript : MonoBehaviour
{
    public ProjectManager pm;
    public GameObject searchInput;
    public GameObject confirmButton;
    public GameObject searchClearPanel;
    public GameObject searchClearBtn;


    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SearchKeywordConfirm();
        }
    }

    public void OnInputTouch()
    {
        ProjectManager.osk = System.Diagnostics.Process.Start("osk.exe");
    }

    public void SearchKeywordConfirm()
    {
        
        CloseKeyboard();
        

        string keyword = searchInput.GetComponent<TMP_InputField>().text;
        searchInput.GetComponent<TMP_InputField>().text = "";

        if (keyword.Length != 0)
        {
            List<Dictionary<string, dynamic>> mapData = new List<Dictionary<string, dynamic>>();
            List<Dictionary<string, dynamic>> searchMapData = new List<Dictionary<string, dynamic>>();

            switch (pm.scale)
            {
                case 0:
                    mapData = pm.mapDataScale1;
                    break;
                case 1:
                    mapData = pm.mapDataScale2;
                    break;
                case 2:
                    mapData = pm.mapDataScale3;
                    break;
                case 3:
                    mapData = pm.mapDataScale4;
                    break;
                default:
                    break;
            }

            foreach (Dictionary<string, dynamic> data in mapData)
            {
                if (data["year"].ToString().Contains(keyword) || data["sheet"].ToLower().Contains(keyword) || data["name"].ToLower().Contains(keyword) || data["name_kor"].Contains(keyword))
                {
                    searchMapData.Add(data);
                }
            }

            //EventSystem에게 mapData를 넘겨줌
            if (searchMapData.Count > 0)
            {
                GameObject scb = Instantiate(searchClearBtn, searchClearPanel.transform);

                GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>().mapData = searchMapData;
                GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>().MapDataItemInit();
            }
        }
    }

    public void CloseKeyboard()
    {
        if (ProjectManager.osk != null)
        {
            ProjectManager.osk.Kill();
            ProjectManager.osk = null;
        }
    }
}
