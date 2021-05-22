using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    public Text YMD;
    private Text YMDText;

    void Date()
    {
       YMDText = GameObject.Find("Month").GetComponent<Text>();

    }
     
}
