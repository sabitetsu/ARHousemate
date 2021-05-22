using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Kirikae : MonoBehaviour
{

    public GameObject situji;
    public GameObject meid;

    public int modelnum;

    // Use this for initialization
    void Start()
    {
        modelnum = 1;
    }

    public void Change()
    {
        modelnum *= -1;
        if (modelnum == 1)
        {

            situji.SetActive(false);
            meid.SetActive(true);
        }

        if (modelnum == -1)
        {

            situji.SetActive(true);
            meid.SetActive(false);
        }

 
    }


        /*
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            situji.SetActive(false);
            meid.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space))
        {

            situji.SetActive(true);
            meid.SetActive(false);

        }

    }
    */
}

    