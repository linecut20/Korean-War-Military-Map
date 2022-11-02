using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFunc : MonoBehaviour
{
    public GameObject panel;
    public GameObject btn;

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("Share Panel(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseButtonTouchedFunc()
    {
        DestroyImmediate(panel, true);
    }
}
