using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class DayTaskScript : MonoBehaviour
{
    [SerializeField] GameObject InputDailyCanvas;
    [SerializeField] GameObject AllShowDailyCanvas;
    [SerializeField] GameObject DailyCanvas;


    void Start()
    {
        List<string[]> dTList = new List<string[]>(); //dayTaskList  t,m,etc
        StreamReader reader = new StreamReader(Application.persistentDataPath + @"\Resources\DayTaskCSV.csv");
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            dTList.Add(line.Split(','));
        }
        reader.Close();
        TopDaily(dTList);  
    }

    public void TopDaily(List<string[]> List)
    {
        var dailyButton = Resources.Load(path: "DailyButton") as GameObject;
        //3つのdayTaskボタンを表示 
        for (int i = 0; i < List.Count; i++)
        {
            var task = Instantiate(dailyButton, DailyCanvas.transform);
            Vector3 pos = task.transform.position;
            pos.y -= i * 80;
            task.transform.position = pos;
            var loadedText = List[i][0] + ":" + List[i][1] + " " + List[i][2] + "の時間";
            var label = task.GetComponentInChildren<Text>();
            label.text = loadedText;
            if (i >= 2)
            {
                break;
            }
        }
    }


    public void OnClick(int dayNum)
    {
        switch (dayNum)
        {
            case 1: //all show
                Instantiate(AllShowDailyCanvas);
                break;

            case 2: //add new
                Instantiate(InputDailyCanvas);
                break;
        }
    }


}
