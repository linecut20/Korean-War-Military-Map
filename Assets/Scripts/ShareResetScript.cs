using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareResetScript : MonoBehaviour
{
    public GameObject resetBtn;
    public GameObject emailInput;
    public GameObject domainDropdown;
    public GameObject domainInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetButtonFunc() {
        emailInput.GetComponent<TMPro.TMP_InputField>().text = "";

        // dropdown selected item text == "직접입력"
        if (domainDropdown.GetComponent<TMPro.TMP_Dropdown>().value == domainDropdown.GetComponent<TMPro.TMP_Dropdown>().options.Count - 1) {
            domainInput.GetComponent<TMPro.TMP_InputField>().text = "";
        }
    }
}
