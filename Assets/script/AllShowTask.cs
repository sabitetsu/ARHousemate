using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AllShowTask : MonoBehaviour
{

    [SerializeField] GameObject content;
    List<string[]> tList = new List<string[]>();
    TaskPush taskPush;
    void Start()
    {
        taskPush = new TaskPush();
        StreamReader reader = new StreamReader(Application.persistentDataPath + @"\Resources\TaskCSV.csv");
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            tList.Add(line.Split(','));
        }
        reader.Close();
        AllShow();
    }

    void AllShow()
    {
        var allTasksPrefab = Resources.Load(path: "AllTask") as GameObject;
        for (int i = 0; i < tList.Count; i++)
        {
            // 2019/12/23 11:22
            // 焼肉食べに行く
            var loadedText = tList[i][0]+"/"+tList[i][1]+"/"+tList[i][2]+" "+tList[i][3]+":"+tList[i][4]+"\n"+tList[i][5];
            var task = Instantiate(allTasksPrefab, content.transform);
            Vector3 pos = task.transform.position;
            pos.y -= i * 120;
            task.transform.position = pos;
            var label = task.GetComponentInChildren<Text>();
            label.text = loadedText;
        }
    }

    public void deleteAST(int bNum)
    {
        if (bNum == 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void deleteTask(int deleteNum)
    {
        tList.RemoveAt(deleteNum);
        var writer = new StreamWriter(Application.persistentDataPath + @"\Resources\TaskCSV.csv", false, Encoding.GetEncoding("UTF-8"));
        for (int i = 0; i < tList.Count; i++)
        {
            writer.WriteLine(tList[i][0] + "," + tList[i][1] + "," + tList[i][2] + "," + tList[i][3] + "," + tList[i][4] + "," + tList[i][5]);
        }
        writer.Close();
        taskPush.DelPush();
        taskPush.InitPush();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Task");
        foreach (GameObject obj in objs)
        {
            Destroy(obj);
        }
        AllShow();
    }
}
