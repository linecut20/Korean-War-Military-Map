using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSceneEventSystem : MonoBehaviour
{
    private int randomCount = 0;
    private Vector3 endPos;
    private GameObject hand;

    public GameObject scaleBtn1;
    public GameObject scaleBtn2;
    public GameObject scaleBtn3;
    public GameObject scaleBtn4;
    public GameObject backgroundHand;
    public GameObject panel;
    public GameObject backgroundCircle;

    // Start is called before the first frame update
    void Start()
    {
        endPos = backgroundCircle.transform.position;
        InvokeRepeating("MapSceneAnimFunc", 30f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        if (endPos != backgroundCircle.transform.position)
        {
            hand.transform.position = Vector3.Lerp(hand.transform.position, endPos, Time.deltaTime * 0.5f);
        }
        else
        {    
            Destroy(hand);
        }
    }

    private void MapSceneAnimFunc()
    {
        hand = Instantiate(backgroundHand, panel.transform);
        hand.transform.position = backgroundCircle.transform.position;

        randomCount = Random.Range(0, 4);

        switch (randomCount)
        {
            case 0:
                endPos = scaleBtn1.transform.position;
                break;

            case 1:
                endPos = scaleBtn2.transform.position;
                break;

            case 2:
                endPos = scaleBtn3.transform.position;
                break;

            case 3:
                endPos = scaleBtn4.transform.position;
                break;
        }

        Invoke("ClearEndPos", 5f);
    }

    private void ClearEndPos()
    {
        endPos = backgroundCircle.transform.position;
    }
}
