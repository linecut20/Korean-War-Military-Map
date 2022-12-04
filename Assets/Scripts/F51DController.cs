using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    public GameObject backgroundCircle;
    public ProjectManager projectManager;

    private Vector3 f51dDefaultPos;
    private bool coroutineFlag = false;
    private bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        projectManager = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        f51dDefaultPos = f51d.transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton1.transform.position) < distance)
        {
            projectManager.scale = 0;
            selected = true;
            
            StartCoroutine("WaitAndGoNext");
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton2.transform.position) < distance)
        {
            projectManager.scale = 1;
            selected = true;
            
            StartCoroutine("WaitAndGoNext");
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton3.transform.position) < distance)
        {
            projectManager.scale = 2;
            selected = true;
            
            StartCoroutine("WaitAndGoNext");
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(f51d.transform.position, scaleButton4.transform.position) < distance)
        {
            projectManager.scale = 3;
            selected = true;
            
            StartCoroutine("WaitAndGoNext");
        }

        //대기상태
        if (Input.GetMouseButton(0) == false)
        {
            if (!coroutineFlag)
            {
                coroutineFlag = true;
                StartCoroutine("BackgroundCircleLightFunc");
            }

            if (!selected) {
                f51d.transform.position = Vector3.Lerp(f51d.transform.position, f51dDefaultPos, Time.deltaTime * 2f);
            } else {
                f51d.transform.localScale = Vector3.Lerp(f51d.transform.localScale, new Vector3(0.35f, 0.35f, 0.35f), 2f * Time.deltaTime);
            }
        }
        else
        {
            //backgroundCircle 색상 및 bool 초기화
            backgroundCircle.GetComponent<Image>().color = new Color(1,1,1,1);
            coroutineFlag = false;
            StopCoroutine("BackgroundCircleLightFunc");
        }
    }
    
    private IEnumerator WaitAndGoNext() {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        f51d.transform.position += (Vector3)eventData.delta;
        if (Vector3.Distance(f51d.transform.position, scaleButton1.transform.position) < distance)
        {
            scaleButton1.GetComponent<UnityEngine.UI.Image>().sprite = menu_on[0];
        }
        else
        {
            scaleButton1.GetComponent<UnityEngine.UI.Image>().sprite = menu_off[0];
        }
        if (Vector3.Distance(f51d.transform.position, scaleButton2.transform.position) < distance)
        {
            scaleButton2.GetComponent<UnityEngine.UI.Image>().sprite = menu_on[1];
        }
        else
        {
            scaleButton2.GetComponent<UnityEngine.UI.Image>().sprite = menu_off[1];
        }
        if (Vector3.Distance(f51d.transform.position, scaleButton3.transform.position) < distance)
        {
            scaleButton3.GetComponent<UnityEngine.UI.Image>().sprite = menu_on[2];
        }
        else
        {
            scaleButton3.GetComponent<UnityEngine.UI.Image>().sprite = menu_off[2];
        }
        if (Vector3.Distance(f51d.transform.position, scaleButton4.transform.position) < distance)
        {
            scaleButton4.GetComponent<UnityEngine.UI.Image>().sprite = menu_on[3];
        }
        else
        {
            scaleButton4.GetComponent<UnityEngine.UI.Image>().sprite = menu_off[3];
        }
    }


    private IEnumerator BackgroundCircleLightFunc()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            backgroundCircle.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 0.7f);

            yield return new WaitForSeconds(0.5f);
            backgroundCircle.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, 1f);
        }

    }
}
