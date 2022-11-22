using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShareDomainChange : MonoBehaviour
{
    public GameObject domainDropdown;
    public GameObject domainInputArea;

    // Start is called before the first frame update
    void Start()
    {
        domainInputArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DomainDropdownValueChangedFunc() {
        //domainDropdown close menu;
        domainDropdown.GetComponent<TMP_Dropdown>().Hide();

        //domainInputArea clear
        domainInputArea.GetComponent<TMP_InputField>().text = "";
        if (domainDropdown.GetComponent<TMP_Dropdown>().value == 5) {
            domainInputArea.SetActive(true);
        } else {
            domainInputArea.SetActive(false);
        }

        Debug.Log(domainDropdown.GetComponent<TMP_Dropdown>().value);
    }
}
