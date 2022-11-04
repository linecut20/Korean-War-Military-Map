using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchScript : MonoBehaviour
{
    public GameObject searchInput;
    public GameObject searchText;
    public GameObject confirmButton;

    // Start is called before the first frame update
    void Start()
    {
        searchInput = GameObject.Find("Search Input");
        searchText = GameObject.Find("Search Text");
        confirmButton = GameObject.Find("Confirm Button");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputTouch()
    {
        if (System.Diagnostics.Process.GetProcessesByName("OSK").Length > 0)
        {
            System.Diagnostics.Process.GetProcessesByName("OSK")[0].MainWindowHandle.ToInt32();
        }
        else
        {

            System.Diagnostics.Process.Start("OSK.exe");
        }
    }
}
