using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraForIndexPageScript : MonoBehaviour
{
    public GameObject mapCamera;

    private float m_DoubleClickSecond = 0.5f;
    private bool m_IsOneClick = false;
    private double m_Timer = 0;

    private float doubleTapZoom = 150.0f;
    private float maxZoom = 180f;
    private float currentZoom = 0f;

    private float minX = -46.1f;
    private float maxX = 99.8f;
    private float minY = -57.95f;
    private float maxY = 88.925f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    float preDistance = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began)
        {
            preDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
        }

        if (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            float deltaDistance = 0;

            float distance = Vector3.Distance(Input.touches[0].position, Input.touches[1].position);

            deltaDistance = distance - preDistance;
            preDistance = distance;


            OnPinchZoom(deltaDistance);
            return;
        }

        if (Input.touchCount == 1)
        {
            if (m_IsOneClick && ((Time.time - m_Timer) > m_DoubleClickSecond))
            {
                m_IsOneClick = false;
            }

            if (Input.touches[0].phase == TouchPhase.Began)
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

            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                OnMouseDrag2();
            }
        }
    }

    public void OnPinchZoom(float scale)
    {
        currentZoom = mapCamera.transform.position.z + scale * 0.2f;

        if (currentZoom <= 0)
        {
            currentZoom = 0;
        }
        else if (currentZoom >= maxZoom)
        {
            currentZoom = maxZoom;
        }
        else
        {
            print("currentZoom : " + currentZoom);
            print("deltaDistance : " + scale);
            currentZoom += scale * 0.02f;
        }
        print(scale);
        float xMin = (currentZoom / maxZoom) * minX;
        float xMax = (currentZoom / maxZoom) * maxX;
        float yMin = (currentZoom / maxZoom) * minY;
        float yMax = (currentZoom / maxZoom) * maxY;

        mapCamera.transform.position = new Vector3(mapCamera.transform.position.x, mapCamera.transform.position.y, currentZoom);

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

    void OnMouseDrag2()
    {
        if (mapCamera.transform.position.z > 0)
        {
            //드래그하는 방향으로 mapCamera 이동
            // float x = Input.GetAxis("Mouse X");
            // float y = Input.GetAxis("Mouse Y");

            float x = Input.touches[0].deltaPosition.x * 0.02f;
            float y = Input.touches[0].deltaPosition.y * 0.02f;

            // (doubleTapZoom / mapCamera.transfrom.position.z) * minX, maxX, minY, maxY 의 값으로 제한;

            xMin = mapCamera.transform.position.z / maxZoom * minX;
            xMax = mapCamera.transform.position.z / maxZoom * maxX;
            yMin = mapCamera.transform.position.z / maxZoom * minY;
            yMax = mapCamera.transform.position.z / maxZoom * maxY;

            //x 이동범위 내 (좌축)
            if ((mapCamera.transform.position.x + x >= xMin) && x > 0)
            {
                if (mapCamera.transform.position.x >= xMin)
                {
                    mapCamera.transform.Translate(-x * 5, 0, 0);
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
                    mapCamera.transform.Translate(-x * 5, 0, 0);
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
                    mapCamera.transform.Translate(0, -y * 5, 0);
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
                    mapCamera.transform.Translate(0, -y * 5, 0);
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
