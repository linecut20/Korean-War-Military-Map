using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSharePanel : MonoBehaviour
{
    public GameObject sharePanel;
    public GameObject shareButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShareButtonTouchedFunc()
    {
        //show messagebox
        sharePanel.SetActive(true);
    }
}
