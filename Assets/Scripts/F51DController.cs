using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class F51DController : MonoBehaviour
{
    public GameObject f51d;
    
    public GameObject scaleButton1;
    public GameObject scaleButton2;
    public GameObject scaleButton3;
    public GameObject scaleButton4;

    public ProjectManager projectManager;
    // Start is called before the first frame update
    void Start()
    {
        projectManager = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton1.transform.position) < 10) {
            projectManager.scale = 0;
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton2.transform.position) < 10) {
            projectManager.scale = 1;
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton3.transform.position) < 10) {
            projectManager.scale = 2;
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton4.transform.position) < 10) {
            projectManager.scale = 3;
            SceneManager.LoadScene(1);
        }

        if(Input.GetMouseButton(0) == false) {
            f51d.transform.position = Vector3.Lerp(f51d.transform.position, new Vector3(0, 0, 0), Time.deltaTime * 2f);
        }
    }

    void OnMouseDrag()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(f51d.transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        f51d.transform.position = worldPosition;             

        if (Vector3.Distance(f51d.transform.position, scaleButton1.transform.position) < 10)
        {
            scaleButton1.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 96, 186);
            scaleButton1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255);
        } else {
            scaleButton1.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            scaleButton1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        }
        if (Vector3.Distance(f51d.transform.position, scaleButton2.transform.position) < 10)
        {
            scaleButton2.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 96, 186);
            scaleButton2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255);
        } else {
            scaleButton2.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            scaleButton2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        }

        if (Vector3.Distance(f51d.transform.position, scaleButton3.transform.position) < 10)
        {
            scaleButton3.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 96, 186);
            scaleButton3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255);
        } else {
            scaleButton3.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            scaleButton3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        }

        if (Vector3.Distance(f51d.transform.position, scaleButton4.transform.position) < 10)
        {
            scaleButton4.GetComponent<UnityEngine.UI.Image>().color = new Color(0, 96, 186);
            scaleButton4.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255);
        } else {
            scaleButton4.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            scaleButton4.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black;
        }
    }

    private RaycastHit CastRay() {
        Vector3 screenMousePosFar = new Vector3 (
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
        );

        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane
        );

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}
