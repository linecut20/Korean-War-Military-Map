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

    public void OnInputTouch() {
        TouchScreenKeyboard.Open("");
    }
}
