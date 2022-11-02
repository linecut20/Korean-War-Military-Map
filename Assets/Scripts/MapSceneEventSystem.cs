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
    
    private int scale = 0;

    void Start()
    {
        
        projectManager = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        scale = projectManager.scale;

        LoadJson();

        for (int i = 0; i < mapData.Count ; i++) {
            GameObject newPrefabs = Instantiate(resultItem, content.transform);
        
            newPrefabs.transform.Find("year").GetComponent<TextMeshProUGUI>().text = mapData[i]["year"].ToString();
            newPrefabs.transform.Find("sheet").GetComponent<TextMeshProUGUI>().text = mapData[i]["sheet"];
            newPrefabs.transform.Find("name").GetComponent<TextMeshProUGUI>().text = mapData[i]["name"];

            int idx = i;
            //newPrefabs에 대한 터치 이벤트 구현
            newPrefabs.GetComponent<Button>().onClick.AddListener(() => {
                OnItemTouched(idx);
            });
        }

        OnItemTouched(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //json 데이터 호출
    public void LoadJson() {
        using (StreamReader r = new StreamReader("Assets/data/sample_data.json"))
        {
            string json = r.ReadToEnd();
            mapData = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(json);
        }
    }

    //스테이터스 창의 내용을 변경
    public void OnItemTouched(int idx) {
        mapCamera.transform.position = new Vector3(0, 0, 0);
        projectManager.mapData = mapData[idx];
        time.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["time"];
        source.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["source"];
        present.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["present"];
        number.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["number"].ToString();
        amount.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["amount"] + "면";
        connection.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["connection"];
        summary.GetComponent<TextMeshProUGUI>().text = projectManager.mapData["summary"];
        UpdateMap(projectManager.mapData["image_path"]);
    }

    public void UpdateMap(String path) {
        //mat의 이미지를 변경
        mat = imageArea.GetComponent<Renderer>().material;
        
        Texture2D tex = new Texture2D(2, 2);
            byte[] fileData = File.ReadAllBytes(path);
            tex.LoadImage(fileData);
            mat.mainTexture = tex;
    }
}
