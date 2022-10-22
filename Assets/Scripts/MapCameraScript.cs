using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraScript : MonoBehaviour
{
    public GameObject mapCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //터치 카운트가 2개 이상일 경우 (Pinch in & out)
        if (Input.touchCount == 2)
        {
            //get touch position
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            //get touch position
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            //get magnitude
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            //get difference
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            //zoom
            mapCamera.GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * Time.deltaTime;
        }


        //when doubleClick, map Camera zoom in
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Input.GetTouch(0).tapCount == 2)
            {
                Debug.Log("double");
                mapCamera.GetComponent<Camera>().orthographicSize = 1.5f;
            }
        }
    }
}
