using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AllShowDaily : MonoBehaviour
{
    [SerializeField] GameObject content;
    List<string[]> dTList = new List<string[]>();
    TaskPush taskPush;
    DayTaskScript DTS;

    void Start()
    {
        taskPush = new TaskPush();
        DTS = new DayTaskScript();
        StreamReader reader = new StreamReader(Application.persistentDataPath + @"\Resources\DayTaskCSV.csv");
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            dTList.Add(line.Split(','));
        }
        reader.Close();
        ShowAll();
    }

    void ShowAll()
    {
        var allTasksPrefab = Resources.Load(path: "AllDaily") as GameObject;
        for (int i = 0; i< dTList.Count; i++)
        {
            var loadedText = dTList[i][0] +":"+dTList[i][1]+" "+dTList[i][2];
            var task = Instantiate(allTasksPrefab, content.transform);
            Vector3 pos = task.transform.position;
            pos.y -= i * 90;
            task.transform.position = pos;
            var label = task.GetComponentInChildren<Text>();
            label.text = loadedText;
        }
    }

    public void deleteASD(int bNum)
    {
        if(bNum == 1)
        {
            Destroy(this.gameObject);
        }
    }


    public void deleteTask(int deleteNum)
    {
        dTList.RemoveAt(deleteNum);
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + @"\Resources\DayTaskCSV.csv", false, Encoding.GetEncoding("UTF-8"));
        for(int i = 0; i < dTList.Count; i++)
        {
            writer.WriteLine(dTList[i][0]+","+dTList[i][1]+","+dTList[i][2]);
        }
        writer.Close();
        taskPush.DelPush();
        taskPush.InitPush();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Daily");
        foreach(GameObject obj in objs)
        {
            Destroy(obj);
        }
        ShowAll();
        DTS.TopDaily(dTList);
    }

    
}
