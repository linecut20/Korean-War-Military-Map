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

    private float doubleTapZoom = 60.0f;
    private float maxZoom = 80;

    private float minX = -60.48f;
    private float maxX = 82.38f;
    private float minY = -40.9f;
    private float maxY = 47.1f;

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
                            mapCamera.transform.position = new Vector3(hit.point.x, hit.point.y, doubleTapZoom);

                            float xMin = (mapCamera.transform.position.z / maxZoom) * minX;
                            float xMax = (mapCamera.transform.position.z / maxZoom) * maxX;
                            float yMin = (mapCamera.transform.position.z / maxZoom) * minY;
                            float yMax = (mapCamera.transform.position.z / maxZoom) * maxY;

                            if (mapCamera.transform.position.x < xMin)
                            {
                                mapCamera.transform.position = new Vector3(xMin, mapCamera.transform.position.y, mapCamera.transform.position.z);
                            }
                            else if (mapCamera.transform.position.x > xMax)
                            {
                                mapCamera.transform.position = new Vector3(xMax, mapCamera.transform.position.y, mapCamera.transform.position.z);
                            }

                            if (mapCamera.transform.position.y < yMin)
                            {
                                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, yMin, mapCamera.transform.position.z);
                            }
                            else if (mapCamera.transform.position.y > yMax)
                            {
                                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, yMax, mapCamera.transform.position.z);
                            }
                        }
                    }
                }
            }
        }
    }

    //pinch zoom
    public void OnPinchZoom(float scale)
    {
        if (mapCamera.transform.position.z >= 0 && mapCamera.transform.position.z <= maxZoom)
        {
            mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, mapCamera.transform.position.y, mapCamera.transform.position.z * scale);
        }
    }

    void OnMouseDrag()
    {
        if (mapCamera.transform.position.z > 0)
        {
            //드래그하는 방향으로 mapCamera 이동
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            // (doubleTapZoom / mapCamera.transfrom.position.z) * minX, maxX, minY, maxY 의 값으로 제한
            float xMin = (mapCamera.transform.position.z / maxZoom) * minX;
            float xMax = (mapCamera.transform.position.z / maxZoom) * maxX;
            float yMin = (mapCamera.transform.position.z / maxZoom) * minY;
            float yMax = (mapCamera.transform.position.z / maxZoom) * maxY;

            //x 이동범위 내 (좌축)
            if ((mapCamera.transform.position.x + x >= xMin) && x > 0)
            {
                if (mapCamera.transform.position.x >= xMin)
                {

                    mapCamera.transform.Translate(-x * 2, 0, 0);
                }
                else
                {
                    mapCamera.transform.position = new Vector3(xMin, mapCamera.transform.position.y, mapCamera.transform.position.z);
                }
            }

            //x 이동범위 내 (우측) 
            if ((mapCamera.transform.position.x + x <= xMax) && x < 0)
            {
                if (mapCamera.transform.position.x <= xMax)
                {
                    mapCamera.transform.Translate(-x * 2, 0, 0);
                }
                else
                {
                    mapCamera.transform.position = new Vector3(xMax, mapCamera.transform.position.y, mapCamera.transform.position.z);
                }
            }

            //y 이동범위 내 (좌측) 
            if ((mapCamera.transform.position.y + y >= yMin) && y > 0)
            {
                if (mapCamera.transform.position.y >= yMin)
                {
                    mapCamera.transform.Translate(0, -y * 2, 0);
                }
                else
                {
                    mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, yMin, mapCamera.transform.position.z);
                }
            }

            //y 이동범위 내 (우측)
            if ((mapCamera.transform.position.y + y <= yMax) && y < 0)
            {
                if (mapCamera.transform.position.y <= yMax)
                {
                    mapCamera.transform.Translate(0, -y * 2, 0);
                }
                else
                {
                    mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, yMax, mapCamera.transform.position.z);
                }
            }

            //x 이동범위 밖(좌측)
            if ((mapCamera.transform.position.x + x < xMin) && x > 0)
            {
                mapCamera.transform.position = new Vector3(xMin, mapCamera.transform.position.y, mapCamera.transform.position.z);

            }

            //x 이동범위 밖(우측)
            if ((mapCamera.transform.position.x + x > xMax) && x < 0)
            {
                mapCamera.transform.position = new Vector3(xMax, mapCamera.transform.position.y, mapCamera.transform.position.z);
            }

            //y 이동범위 밖(좌측)
            if ((mapCamera.transform.position.y + y < yMin) && y > 0)
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, yMin, mapCamera.transform.position.z);
            }

            //y 이동범위 밖(우측)
            if ((mapCamera.transform.position.y + y > yMax) && y < 0)
            {
                mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, yMax, mapCamera.transform.position.z);
            }
        }
    }
}
