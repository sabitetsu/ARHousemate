using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//未完成

public class Swipe : MonoBehaviour
{
    public float StartPos;
    public float EndPos;
    Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPos = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndPos = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            if (StartPos > EndPos)
            {
                mainCamera.transform.position = new Vector3(transform.position.x + 10, transform.position.y, -10);
            }
            else if (StartPos < EndPos)
            {
                mainCamera.transform.position = new Vector3(transform.position.x - 10, transform.position.y, -10);
            }
            StartPos = 0;
            EndPos = 0;
        }
    }
}