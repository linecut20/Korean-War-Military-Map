using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraScript : MonoBehaviour
{
    public GameObject imageArea;
    public GameObject mapCamera;

    private float m_DoubleClickSecond = 0.25f;
    private bool m_IsOneClick = false;
    private double m_Timer = 0;

    private float doubleTapZoom = 70.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (m_IsOneClick && ((Time.time - m_Timer) > m_DoubleClickSecond))
        {
            m_IsOneClick = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //double 클릭 구현
            if (!m_IsOneClick)
            {
                m_Timer = Time.time;
                m_IsOneClick = true;
            }
            else if (m_IsOneClick && ((Time.time - m_Timer) < m_DoubleClickSecond))
            {
                //when double click
                m_IsOneClick = false;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //imageArea에 대한 double click 시..
                    if (hit.collider.gameObject == imageArea)
                    {
                        if (mapCamera.transform.position.z > 0)
                        {
                            //축소 (z => 0)
                            mapCamera.transform.position = new Vector3(0, 0, 0);
                        }
                        else
                        {
                            //확대 (z => doubleTapZoom)
                            mapCamera.transform.position = new Vector3(hit.point.x, hit.point.y, doubleTapZoom);
                        }
                    }
                }
            }
        }
    }

    //pinch zoom
    public void OnPinchZoom(float scale)
    {
        if (mapCamera.transform.position.z >= 0)
        {
            mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, mapCamera.transform.position.y, mapCamera.transform.position.z + scale);
        }
    }

    void OnMouseDrag()
    {
        if (mapCamera.transform.position.z > 0)
        {
            //드래그하는 방향으로 mapCamera 이동
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            mapCamera.transform.Translate((-x * 2), (-y * 2), 0);
        }
    }
}
