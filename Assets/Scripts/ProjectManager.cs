using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using System.Diagnostics;

public class ProjectManager : MonoBehaviour
{
    public static ProjectManager instance = null;

    public int scale;
    public int tutorialIndex;
    public bool touched = false;
    public List<Dictionary<string, dynamic>> mapDataScale1 = new List<Dictionary<string, dynamic>>();
    public List<Dictionary<string, dynamic>> mapDataScale2 = new List<Dictionary<string, dynamic>>();
    public List<Dictionary<string, dynamic>> mapDataScale3 = new List<Dictionary<string, dynamic>>();
    public List<Dictionary<string, dynamic>> mapDataScale4 = new List<Dictionary<string, dynamic>>();

    private string basePath = Application.streamingAssetsPath;
    public Dictionary<string, dynamic> mapData = new Dictionary<string, dynamic>();
    public static Process osk;

    public int pinchAnimTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            LoadJson();
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //json 데이터 호출
    public void LoadJson()
    {
        using (StreamReader r = new StreamReader(basePath + "/50000json.json"))
        {
            string json = r.ReadToEnd();
            mapDataScale1 = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(json);
        }

        using (StreamReader r = new StreamReader(basePath + "/250000json.json"))
        {
            string json = r.ReadToEnd();
            mapDataScale2 = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(json);
        }

        using (StreamReader r = new StreamReader(basePath + "/500000json.json"))
        {
            string json = r.ReadToEnd();
            mapDataScale3 = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(json);
        }

        using (StreamReader r = new StreamReader(basePath + "/1000000json.json"))
        {
            string json = r.ReadToEnd();
            mapDataScale4 = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(json);
        }
    }
}
