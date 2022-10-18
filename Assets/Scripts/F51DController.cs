using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F51DController : MonoBehaviour
{
    public GameObject f51d;
    Vector3 mousePositionOffset;

    // Start is called before the first frame update
    void Start()
    {
        f51d = GameObject.Find("F-51D");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 getMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 32;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDown()
    {
        mousePositionOffset = f51d.transform.position - getMouseWorldPosition();

    }

    void OnMouseDrag()
    {
        f51d.transform.position = getMouseWorldPosition() + mousePositionOffset;
    }

    void OnMouseUp()
    {
        f51d.transform.position = new Vector3(0, 0, 32);
    }
}
