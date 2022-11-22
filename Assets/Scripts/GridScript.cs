using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GridScript : MonoBehaviour
{
    public GameObject gridItem;
    public GameObject content;
    public GameObject loadingText;
    public ProjectManager pm;
    public MapSceneEventSystem es;

    private List<Dictionary<string, dynamic>> mapDataList = new List<Dictionary<string, dynamic>>();
    private string basePath = Application.streamingAssetsPath;
    private Material mat;
    private Texture2D tex;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Init", 1f);
    }

    private void Init()
    {
        es = GameObject.Find("EventSystem").GetComponent<MapSceneEventSystem>();
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        switch (pm.scale)
        {
            case 0:
                mapDataList = pm.mapDataScale1;
                break;

            case 1:
                mapDataList = pm.mapDataScale2;
                break;

            case 2:
                mapDataList = pm.mapDataScale3;
                break;

            case 3:
                mapDataList = pm.mapDataScale4;
                break;
        }

        //mapdataList의 사이즈가 30이 넘어가면 30으로 고정
        if (mapDataList.Count > 24)
        {
            mapDataList.RemoveRange(24, mapDataList.Count - 24);
        }

        for (int i = 0; i < mapDataList.Count; i++)
        {
            UpdateGridItem(basePath + mapDataList[i]["image_path"], mapDataList[i]["name_kor"], i);
        }

        loadingText.SetActive(false);
        // mapDataList.ForEach((mapData) => {
        //     UpdateGridItem(basePath + mapData["image_path"], mapData["name_kor"]);
        // });
    }

    private void UpdateGridItem(string path, string name, int index)
    {
        GameObject newPrefabs = Instantiate(gridItem, content.transform);

        // mat = newPrefabs.GetComponent<RawImage>().material;

        tex = new Texture2D(1, 1);
        byte[] fileData = File.ReadAllBytes(path);
        tex.LoadImage(fileData);
        newPrefabs.GetComponent<RawImage>().texture = tex;

        // mat.mainTexture = tex;

        newPrefabs.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;

        newPrefabs.GetComponent<Button>().onClick.AddListener(() =>
        {
            es.OnItemTouched(index);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
