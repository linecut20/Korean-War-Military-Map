using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSharePanel : MonoBehaviour
{
    public GameObject sharePanel;
    public GameObject shareButton;
    public GameObject canvas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShareButtonTouchedFunc()
    {
        GameObject newPref = Instantiate(sharePanel, canvas.transform);
        newPref.transform.SetAsLastSibling();
    }
}
