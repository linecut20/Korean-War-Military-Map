using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class F51DController : MonoBehaviour, IDragHandler
{
    public GameObject f51d;
    public Sprite[] menu_on;
    public Sprite[] menu_off;

    public float distance;
    public GameObject scaleButton1;
    public GameObject scaleButton2;
    public GameObject scaleButton3;
    public GameObject scaleButton4;
    private Vector3 f51dDefaultPos;

    public ProjectManager projectManager;
    // Start is called before the first frame update
    void Start()
    {
        projectManager = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        f51dDefaultPos = f51d.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton1.transform.position) < distance) {
            projectManager.scale = 0;
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton2.transform.position) < distance) {
            projectManager.scale = 1;
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton3.transform.position) < distance) {
            projectManager.scale = 2;
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton4.transform.position) < distance) {
            projectManager.scale = 3;
            SceneManager.LoadScene(1);
        }

        if(Input.GetMouseButton(0) == false) {
            f51d.transform.position = Vector3.Lerp(f51d.transform.position, f51dDefaultPos, Time.deltaTime * 2f);
        }
    }

    // public void OnMouseDrag()
    // {
    //     Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(f51d.transform.position).z);
    //     Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

    //     f51d.transform.position = worldPosition;

        
    // }

    public void OnDrag(PointerEventData eventData)
    {
        f51d.transform.position += (Vector3)eventData.delta;
        if (Vector3.Distance(f51d.transform.position, scaleButton1.transform.position) < distance)
        {   
            scaleButton1.GetComponent<UnityEngine.UI.Image>().sprite = menu_on[0];
        } else {
            scaleButton1.GetComponent<UnityEngine.UI.Image>().sprite = menu_off[0];
        }
        if (Vector3.Distance(f51d.transform.position, scaleButton2.transform.position) < distance)
        {   
            scaleButton2.GetComponent<UnityEngine.UI.Image>().sprite = menu_on[1];
        } else {
            scaleButton2.GetComponent<UnityEngine.UI.Image>().sprite = menu_off[1];
        }
        if (Vector3.Distance(f51d.transform.position, scaleButton3.transform.position) < distance)
        {   
            scaleButton3.GetComponent<UnityEngine.UI.Image>().sprite = menu_on[2];
        } else {
            scaleButton3.GetComponent<UnityEngine.UI.Image>().sprite = menu_off[2];
        }
        if (Vector3.Distance(f51d.transform.position, scaleButton4.transform.position) < distance)
        {   
            scaleButton4.GetComponent<UnityEngine.UI.Image>().sprite = menu_on[3];
        } else {
            scaleButton4.GetComponent<UnityEngine.UI.Image>().sprite = menu_off[3];
        }
    }
}
