using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGridPanel : MonoBehaviour
{
    public GameObject canvas;
    public GameObject grid50000;
    public GameObject grid250000;
    public GameObject grid500000;
    public GameObject grid1000000;
    public GameObject naviCanvas;
    public ProjectManager pm;

    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GridButtonTouchedFunc()
    {
        GameObject grid = null;

        switch (pm.scale)
        {
            case 0:
                grid = GameObject.Find("GridPanel50000(Clone)");

                if (grid == null)
                {
                    GameObject newPrefab = Instantiate(grid50000, canvas.transform);
                }
                else
                {
                    Destroy(grid);
                }
                break;

            case 1:
                grid = GameObject.Find("GridPanel250000(Clone)");

                if (grid == null)
                {
                    GameObject newPrefab = Instantiate(grid250000, canvas.transform);
                }
                else
                {
                    Destroy(grid);
                }
                break;

            case 2:
                grid = GameObject.Find("GridPanel500000(Clone)");

                if (grid == null)
                {
                    GameObject newPrefab = Instantiate(grid500000, canvas.transform);
                }
                else
                {
                    Destroy(grid);
                }
                break;

            case 3:
                grid = GameObject.Find("GridPanel1000000(Clone)");

                if (grid == null)
                {
                    GameObject newPrefab = Instantiate(grid1000000, canvas.transform);
                }
                else
                {
                    Destroy(grid);
                }
                break;
        }
    }
}
