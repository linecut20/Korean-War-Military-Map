using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F51DScaleScript : MonoBehaviour
{
    public GameObject f51d;

    public float distance;
    public GameObject scaleButton1;
    public GameObject scaleButton2;
    public GameObject scaleButton3;
    public GameObject scaleButton4;

    private Vector3 f51dDefaultPos;
    private bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        f51dDefaultPos = f51d.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton1.transform.position) < distance || Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton2.transform.position) < distance || Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton3.transform.position) < distance || Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton4.transform.position) < distance)
        {
            selected = true;
            f51d.transform.localScale = Vector3.Lerp(f51d.transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), 0.1f * Time.deltaTime);
        }

        //  if (Input.GetMouseButton(0) == false) {
        //     f51d.transform.position = Vector3.Lerp(f51d.transform.position, f51dDefaultPos, Time.deltaTime * 2f);
        //  }
    }
}
