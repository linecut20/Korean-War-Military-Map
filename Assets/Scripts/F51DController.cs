using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class F51DController : MonoBehaviour
{
    public GameObject f51d;
    public GameObject scaleButton1;
    public GameObject scaleButton2;
    public GameObject scaleButton3;
    public GameObject scaleButton4;

    // Start is called before the first frame update
    void Start()
    {
        f51d = GameObject.Find("F-51D");
        scaleButton1 = GameObject.Find("ScaleButton1");
        scaleButton2 = GameObject.Find("ScaleButton2");
        scaleButton3 = GameObject.Find("ScaleButton3");
        scaleButton4 = GameObject.Find("ScaleButton4");
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton1.transform.position) < 5) {
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton2.transform.position) < 5) {
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton3.transform.position) < 5) {
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton4.transform.position) < 5) {
            SceneManager.LoadScene(1);
        }

        f51d.transform.position = Vector3.Lerp(f51d.transform.position, new Vector3(0, 0, 0), Time.deltaTime * 2f);
    }

    void OnMouseDrag()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(f51d.transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        f51d.transform.position = worldPosition;             
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
