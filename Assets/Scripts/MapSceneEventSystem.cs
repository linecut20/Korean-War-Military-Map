using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class MapSceneEventSystem : MonoBehaviour
{
    public List<Dictionary<string, dynamic>> mapData = new List<Dictionary<string, dynamic>>();
    public GameObject canvas;
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
    public GameObject btnShare;
    public GameObject indexImage50000;
    public GameObject indexImage250000;
    public GameObject indexImage500000;
    public GameObject indexImage1000000;
    public GameObject topButton;
    public GameObject noMapPanel;
    public GameObject naviCanvas;
    public GameObject naviPointer;
    public GameObject pinchAnim;
    private Material mat;
    private Texture2D tex;

    public ProjectManager projectManager;
    private string basePath = Application.streamingAssetsPath;
    private int timer = 600;
    private int pinchAnimTimer = 120;

    private SearchScript searchScript;
    private Vector3 viewPos = new Vector3(0, 0, 0);

    void Start()
    {
        StartCoroutine("Timer");
        StartCoroutine("PinchAnimTimer");
        //인덱스 이미지 패널을 활성화하기 위해 imageArea를 비활성화
        imageArea.SetActive(false);
        topButton.SetActive(false);
        pinchAnim.SetActive(false);

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            btnShare.SetActive(false);
        }

        projectManager = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        GetMapDataList(projectManager.scale);
        MapDataItemInit();

        // OnItemTouched(0);

        // naviCanvas.transform.position = new Vector3(41.9f, 154, 199.9f);
        // naviPointer.transform.position = new Vector3(37.3f, 8.9f, 199f);

        if (mapCamera.transform.position.z >= 50)
        {
            naviCanvas.SetActive(true);
            naviPointer.SetActive(true);
        }
        else
        {
            naviCanvas.SetActive(false);
            naviPointer.SetActive(false);
        }

    }

    public void IndexImageInit()
    {
        indexImage50000.SetActive(false);
        indexImage250000.SetActive(false);
        indexImage500000.SetActive(false);
        indexImage1000000.SetActive(false);

        switch (projectManager.scale)
        {
            case 0:
                indexImage50000.SetActive(true);
                break;

            case 1:
                indexImage250000.SetActive(true);
                break;
            case 2:
                indexImage500000.SetActive(true);
                break;

            case 3:
                indexImage1000000.SetActive(true);
                break;
        }

        amount.GetComponent<TextMeshProUGUI>().text = mapData.Count + "면";
    }

    public void OnMouseDown()
    {

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

            // newPrefabs.transform.Find("year").GetComponent<TextMeshProUGUI>().text = "";
            newPrefabs.transform.Find("year").GetComponent<TextMeshProUGUI>().text = mapData[i]["year"].ToString();
            newPrefabs.transform.Find("sheet").GetComponent<TextMeshProUGUI>().text = mapData[i]["sheet"];
            newPrefabs.transform.Find("name").GetComponent<TextMeshProUGUI>().text = mapData[i]["name"];
            newPrefabs.transform.Find("name_kor").GetComponent<TextMeshProUGUI>().text = mapData[i]["name_kor"];

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
        if (Input.anyKey)
        {
            timer = 600;
            pinchAnimTimer = 120;
        }

        //mainCamera의 z값이 50 이상인 경우에만 네비게이션 활성화
        if (mapCamera.transform.position.z >= 50)
        {
            naviCanvas.SetActive(true);
            naviPointer.SetActive(true);
        }
        else
        {
            naviCanvas.SetActive(false);
            naviPointer.SetActive(false);
        }

        if (naviPointer.activeSelf)
        {
            naviPointer.transform.localPosition = new Vector3(mapCamera.transform.position.x * 8.5f, mapCamera.transform.position.y * 8.8f, 0f);
            // Debug.Log(naviPointer.transform.localPosition);
        }
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
        try {
            if (mapData[idx]["image_path"].Length > 0)
            {
                switch (projectManager.scale)
                {
                    case 0:
                        indexImage50000.SetActive(false);
                        break;

                    case 1:
                        indexImage250000.SetActive(false);
                        break;

                    case 2:
                        indexImage500000.SetActive(false);
                        break;

                    case 3:
                        indexImage1000000.SetActive(false);
                        break;
                }

                mapCamera.transform.position = new Vector3(0, 0, 0);
                projectManager.mapData = mapData[idx];

                imageArea.SetActive(true);
                topButton.SetActive(true);
                UpdateMap(basePath + projectManager.mapData["image_path"]);

            }
            else
            {
                GameObject newPref = Instantiate(noMapPanel, canvas.transform);
            }
        } catch {
            
        }
    }

    public void UpdateMap(String path)
    {
        try
        {
            mat = imageArea.GetComponent<Renderer>().material;
            Texture2D tex = new Texture2D(1, 1);
            byte[] fileData = File.ReadAllBytes(path);
            tex.LoadImage(fileData);
            mat.mainTexture = tex;
        }
        catch
        {
            Debug.Log("이미지가 없습니다.");
        }
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            if (timer == 0)
            {
                SceneManager.LoadScene(0);
                break;
            }
        }
    }

    private IEnumerator PinchAnimTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            pinchAnimTimer--;
            if (pinchAnimTimer == 0)
            {
                pinchAnim.SetActive(true);
                yield return new WaitForSeconds(4f);
                pinchAnim.SetActive(false);
            }
        }
    }
}
