using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class ScrollviewInitScript : MonoBehaviour
{
    public List<Dictionary<string, dynamic>> mapData = new List<Dictionary<string, dynamic>>();
    
    public GameObject content;
    public GameObject prefabs;

    
    void Start()
    {
        // var data1 = new Dictionary<string, dynamic>() {
        //     {"year", 1945},
        //     {"sheet",  "L751-6127 IV"},
        //     {"name", "Paengnyong-Do"}
        // };
        // var data2 = new Dictionary<string, dynamic>() {
        //     {"year", 1945},
        //     {"sheet",  "L751-6128 I"},
        //     {"name", "Monggumpo"}
        // };
        // var data3 = new Dictionary<string, dynamic>() {
        //     {"year", 1945},
        //     {"sheet",  "L751-6127 II"},
        //     {"name", "Tok-Tong"}
        // };
        // var data4 = new Dictionary<string, dynamic>() {
        //     {"year", 1947},
        //     {"sheet",  "L751-6129 II"},
        //     {"name", "Chingangpo"}
        // };
        // var data5 = new Dictionary<string, dynamic>() {
        //     {"year", 1947},
        //     {"sheet",  "L751-6130 II"},
        //     {"name", "Tok-To"}
        // };
        
        // mapData.Add(data1);
        // mapData.Add(data2);
        // mapData.Add(data3);
        // mapData.Add(data4);
        // mapData.Add(data5);

        LoadJson();



        

        
        for (int i = 0; i < mapData.Count ; i++) {
            GameObject newPrefabs = Instantiate(prefabs, content.transform);
        
            newPrefabs.transform.Find("year").GetComponent<TextMeshProUGUI>().text = mapData[i]["year"].ToString();
            newPrefabs.transform.Find("sheet").GetComponent<TextMeshProUGUI>().text = mapData[i]["sheet"];
            newPrefabs.transform.Find("name").GetComponent<TextMeshProUGUI>().text = mapData[i]["name"];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadJson() {
        using (StreamReader r = new StreamReader("Assets/data/sample_data.json"))
        {
            string json = r.ReadToEnd();
            mapData = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(json);
        }
    }
}
