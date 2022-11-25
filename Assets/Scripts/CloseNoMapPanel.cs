using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNoMapPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject btn;

    // Start is called before the first frame update
    void Start()
    {
        
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
