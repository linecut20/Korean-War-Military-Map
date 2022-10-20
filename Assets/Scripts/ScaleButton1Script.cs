using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScaleButton1Script : MonoBehaviour
{
    public GameObject button;
    public GameObject f51d;

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("ScaleButton1");
        f51d = GameObject.Find("F-51D");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(f51d.transform.position, button.transform.position) < 10)
        {    
            //button(Unity Ui Button)의 색상을 화이트로 변경
            button.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 96, 186);
            
            //button의 child(Unity Ui Text (TMP))의 색상을 화이트로 변경
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255);
        } else {
            //button(Unity Ui Button)의 색상을 화이트로 변경
            button.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            //button의 child(Unity Ui Text (TMP))의 색상을 화이트로 변경
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        }
    }
}
