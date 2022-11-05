using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MapSceneEventSystem : MonoBehaviour
{
    public List<Dictionary<string, dynamic>> mapData = new List<Dictionary<string, dynamic>>();
    public GameObject content;
    public GameObject resultItem;
    public GameObject time;
    public GameObject source;
    public GameObject present;
    public GameObject number;
    public GameObject amount;
    public GameObject connection;
    public GameObject summary;
    public GameObject imageArea;
    public GameObject mapCamera;
    private Material mat;
    public ProjectManager projectManager;
    private string basePath = Application.streamingAssetsPath;

    void Start()
    {
        projectManager = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        GetMapDataList(projectManager.scale);
        MapDataItemInit();
        
        OnItemTouched(0);
    }

    public void OnMouseDown()
    {
        if (System.Diagnostics.Process.GetProcessesByName("OSK").Length > 0)
        {
            System.Diagnostics.Process.GetProcessesByName("OSK")[0].Kill();
        }
    }

    public void MapDataItemInit()
    {
        //content의 내용 clear
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < mapData.Count; i++)
        {
            GameObject newPrefabs = Instantiate(resultItem, content.transform);

            newPrefabs.transform.Find("year").GetComponent<TextMeshProUGUI>().text = mapData[i]["year"].ToString();
            newPrefabs.transform.Find("sheet").GetComponent<TextMeshProUGUI>().text = mapData[i]["sheet"];
            newPrefabs.transform.Find("name").GetComponent<TextMeshProUGUI>().text = mapData[i]["name"];

            int idx = i;
            //newPrefabs에 대한 터치 이벤트 구현
            newPrefabs.GetComponent<Button>().onClick.AddListener(() =>
            {
                OnItemTouched(idx);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetMapDataList(int scale)
    {
        switch (scale)
        {
            case 0:
                mapData = projectManager.mapDataScale1;
                break;
            case 1:
                mapData = projectManager.mapDataScale2;
                break;
            case 2:
                mapData = projectManager.mapDataScale3;
                break;
            case 3:
                mapData = projectManager.mapDataScale4;
                break;
        }
    }

    //스테이터스 창의 내용을 변경
    public void OnItemTouched(int idx)
    {
        if (projectManager.mapData != mapData[idx])
        {
            mapCamera.transform.position = new Vector3(0, 0, 0);
            projectManager.mapData = mapData[idx];
            time.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["time"];
            source.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["source"];
            present.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["present"];
            number.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["number"].ToString();
            amount.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["amount"] + "면";
            connection.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["connection"];
            summary.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["summary"];
            UpdateMap(basePath + projectManager.mapData["image_path"]);
        }

    }

    public void UpdateMap(String path)
    {
        mat = imageArea.GetComponent<Renderer>().material;

        Texture2D tex = new Texture2D(1, 1);
        byte[] fileData = File.ReadAllBytes(path);
        tex.LoadImage(fileData);

        // //tex의 비율을 유지하면서 imageArea의 크기에 맞게 변경
        // float ratio = (float)tex.width / (float)tex.height;
        // float width = imageArea.transform.localScale.x;
        // float height = imageArea.transform.localScale.y;
        // if (ratio > 1)
        // {
        //     imageArea.transform.localScale = new Vector3(width, width / ratio, 1);
        // }
        // else
        // {
        //     imageArea.transform.localScale = new Vector3(height * ratio, height, 1);
        // }

        mat.mainTexture = tex;
    }
}
